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
    public class ActeursController : ControllerBase
    {
        private readonly APIWeb_ISNContext _context;

        public ActeursController(APIWeb_ISNContext context)
        {
            _context = context;
        }

        // GET: api/Acteurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Acteur>>> GetActeur()
        {
          if (_context.Acteur == null)
          {
              return NotFound();
          }
            return await _context.Acteur.ToListAsync();
        }

        // GET: api/Acteurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Acteur>> GetActeur(int id)
        {
          if (_context.Acteur == null)
          {
              return NotFound();
          }
            var acteur = await _context.Acteur.FindAsync(id);

            if (acteur == null)
            {
                return NotFound();
            }

            return acteur;
        }

        // PUT: api/Acteurs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActeur(int id, Acteur acteur)
        {
            if (id != acteur.IdActeur)
            {
                return BadRequest();
            }

            _context.Entry(acteur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActeurExists(id))
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

        // POST: api/Acteurs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Acteur>> PostActeur(Acteur acteur)
        {
          if (_context.Acteur == null)
          {
              return Problem("Entity set 'APIWeb_ISNContext.Acteur'  is null.");
          }
            _context.Acteur.Add(acteur);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActeur", new { id = acteur.IdActeur }, acteur);
        }

        // DELETE: api/Acteurs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActeur(int id)
        {
            if (_context.Acteur == null)
            {
                return NotFound();
            }
            var acteur = await _context.Acteur.FindAsync(id);
            if (acteur == null)
            {
                return NotFound();
            }

            _context.Acteur.Remove(acteur);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActeurExists(int id)
        {
            return (_context.Acteur?.Any(e => e.IdActeur == id)).GetValueOrDefault();
        }

        
    }
}
