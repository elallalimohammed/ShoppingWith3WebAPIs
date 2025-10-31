using Microsoft.AspNetCore.Mvc;
using UsersWebAPI.Models;
using UsersWebAPI.Repositories;

namespace UsersWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserRepository _repo = new();

        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            var created = _repo.Create(user);
            //return Ok(created);
            // Return 201 Created with a location header
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

       

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _repo.GetUsers();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _repo.GetById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _repo.Delete(id);
            return success ? Ok() : NotFound();
        }
    }
}
