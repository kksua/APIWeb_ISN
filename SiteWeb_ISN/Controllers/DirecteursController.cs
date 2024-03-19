using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIWeb_ISN.Data;
using APIWeb_ISN.Models;

namespace APIWeb_ISN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirecteursController : ControllerBase
    {
        private readonly APIWeb_ISNContext _context;

        public DirecteursController(APIWeb_ISNContext context)
        {
            _context = context;
        }

        // GET: api/Directeurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Directeurs>>> GetDirecteurs()
        {
          if (_context.Directeurs == null)
          {
              return NotFound();
          }
            return await _context.Directeurs.ToListAsync();
        }

        // GET: api/Directeurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Directeurs>> GetDirecteurs(int id)
        {
          if (_context.Directeurs == null)
          {
              return NotFound();
          }
            var directeurs = await _context.Directeurs.FindAsync(id);

            if (directeurs == null)
            {
                return NotFound();
            }

            return directeurs;
        }

        // PUT: api/Directeurs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDirecteurs(int id, Directeurs directeurs)
        {
            if (id != directeurs.IdDirecteurs)
            {
                return BadRequest();
            }

            _context.Entry(directeurs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DirecteursExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Directeurs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Directeurs>> PostDirecteurs(Directeurs directeurs)
        {
          if (_context.Directeurs == null)
          {
              return Problem("Entity set 'APIWeb_ISNContext.Directeurs'  is null.");
          }
            _context.Directeurs.Add(directeurs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDirecteurs", new { id = directeurs.IdDirecteurs }, directeurs);
        }

        // DELETE: api/Directeurs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDirecteurs(int id)
        {
            if (_context.Directeurs == null)
            {
                return NotFound();
            }
            var directeurs = await _context.Directeurs.FindAsync(id);
            if (directeurs == null)
            {
                return NotFound();
            }

            _context.Directeurs.Remove(directeurs);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DirecteursExists(int id)
        {
            return (_context.Directeurs?.Any(e => e.IdDirecteurs == id)).GetValueOrDefault();
        }
    }
}
