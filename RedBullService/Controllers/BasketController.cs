using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using RedbullService.Data;
using RedbullService.Models;

namespace RedbullService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly DataContext _context;

        public BasketController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Basket
        [HttpGet]
        public IActionResult GetAllBaskets()
        {
            var baskets = _context.Basket.ToList();
            return Ok(baskets);
        }

        // GET: api/Basket/5
        [HttpGet("{id}")]
        public IActionResult GetBasket(int id)
        {
            var basket = _context.Basket.FirstOrDefault(b => b.urunId == id);
            if (basket == null)
            {
                return NotFound();
            }
            return Ok(basket);
        }

        // POST: api/Basket
        [HttpPost]
        public IActionResult CreateBasket([FromBody] Basket basket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Basket.Add(basket);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetBasket), new { id = basket.urunId }, basket);
        }

        // PUT: api/Basket/5
        [HttpPut("{id}")]
        public IActionResult UpdateBasket(int id, [FromBody] Basket basket)
        {
            if (id != basket.urunId || !_context.Basket.Any(b => b.urunId == id))
            {
                return BadRequest();
            }

            _context.Entry(basket).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Basket/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {
            var basket = _context.Basket.FirstOrDefault(b => b.urunId == id);
            if (basket == null)
            {
                return NotFound();
            }

            _context.Basket.Remove(basket);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
