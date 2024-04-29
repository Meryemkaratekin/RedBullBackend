using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RedbullService.Data;
using RedbullService.Models;
using System.Linq;

namespace RedbullService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtlethsController : ControllerBase
    {
        private readonly DataContext _context;

        public AtlethsController(DataContext context)
        {
            _context = context;
        }

        // GET /Atleths
        [HttpGet]
        public ActionResult<IEnumerable<Atleths>> GetAtleths()
        {
            var atleths = _context.Atleths.ToList();
            return Ok(atleths);
        }

        // GET /Atleths/{id}
        [HttpGet("{id}")]
        public ActionResult<Atleths> GetAtleth(int id)
        {
            var atleth = _context.Atleths.Find(id);
            if (atleth == null)
            {
                return NotFound();
            }

            return Ok(atleth);
        }

        // POST /Atleths
        [HttpPost]
        public ActionResult<Atleths> CreateAtleth(Atleths newAtleth)
        {
            _context.Atleths.Add(newAtleth);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAtleth), new { id = newAtleth.atlet_id }, newAtleth);
        }

        // PUT /Atleths/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateAtleth(int id, Atleths updatedAtleth)
        {
            if (id != updatedAtleth.atlet_id)
            {
                return BadRequest();
            }

            _context.Entry(updatedAtleth).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE /Atleths/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteAtleth(int id)
        {
            var atleth = _context.Atleths.Find(id);
            if (atleth == null)
            {
                return NotFound();
            }

            _context.Atleths.Remove(atleth);
            _context.SaveChanges();

            return NoContent();
        }
    }

}