using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RedbullService.Data;
using RedbullService.Models;
using System.Collections.Generic;
using System.Linq;

namespace RedbullService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _context.User.ToList();
            return Ok(users);
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _context.User.FirstOrDefault(u => u.kullanici_id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST: api/User
        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.User.Add(user);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetUser), new { id = user.kullanici_id }, user);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User user)
        {
            if (id != user.kullanici_id || !_context.User.Any(u => u.kullanici_id == id))
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _context.User.FirstOrDefault(u => u.kullanici_id == id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
