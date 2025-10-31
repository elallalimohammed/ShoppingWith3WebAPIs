using Microsoft.AspNetCore.Mvc;
using PaymentsWebAPI.Models;
using PaymentsWebAPI.Repositories;

namespace PaymentsWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly PaymentRepository _repo = new();

        [HttpPost]
        public IActionResult PerformPayment(Payment payment)
        {
            var result = _repo.PerformPayment(payment);
            return Ok(result);
        }
    }
}
