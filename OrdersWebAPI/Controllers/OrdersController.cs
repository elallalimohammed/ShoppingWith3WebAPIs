using Microsoft.AspNetCore.Mvc;
using OrdersWebAPI.Models;
using OrdersWebAPI.Repositories;

namespace OrdersWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly OrderRepository _repo = new();
        private readonly HttpClient _client = new();

        private readonly string _usersApi = "http://localhost:5001/api/users";
        private readonly string _paymentsApi = "http://localhost:5002/api/payments";

        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            // Validate user
            var userResponse = await _client.GetAsync($"{_usersApi}/{order.UserId}");
            if (!userResponse.IsSuccessStatusCode)
                return BadRequest("Invalid user.");

            // Perform payment
            var paymentPayload = JsonContent.Create(new { UserId = order.UserId, Amount = order.Amount });
            var paymentResponse = await _client.PostAsync(_paymentsApi, paymentPayload);
            if (!paymentResponse.IsSuccessStatusCode)
                return BadRequest("Payment failed.");

            // Create order
            var created = _repo.Create(order);
            return Ok(created);
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetOrdersByUser(int userId)
        {
            var orders = _repo.GetByUser(userId);
            return Ok(orders);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var success = _repo.Delete(id);
            return success ? Ok() : NotFound();
        }
    }
}
