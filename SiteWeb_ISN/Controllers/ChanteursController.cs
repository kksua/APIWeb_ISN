using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiteWeb_ISN.Data;
using SiteWeb_ISN.Models;

namespace SiteWeb_ISN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChanteursController : ControllerBase
    {
        private readonly SiteWeb_ISNContext _context;

        public ChanteursController(SiteWeb_ISNContext context)
        {
            _context = context;
        }

        // GET: api/Chanteurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chanteur>>> GetChanteur()
        {
          if (_context.Chanteur == null)
          {
              return NotFound();
          }
            return await _context.Chanteur.ToListAsync();
        }

        // GET: api/Chanteurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Chanteur>> GetChanteur(int id)
        {
          if (_context.Chanteur == null)
          {
              return NotFound();
          }
            var chanteur = await _context.Chanteur.FindAsync(id);

            if (chanteur == null)
            {
                return NotFound();
            }

            return chanteur;
        }

        // PUT: api/Chanteurs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChanteur(int id, Chanteur chanteur)
        {
            if (id != chanteur.IdChanteur)
            {
                return BadRequest();
            }

            _context.Entry(chanteur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChanteurExists(id))
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

        // POST: api/Chanteurs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Chanteur>> PostChanteur(Chanteur chanteur)
        {
          if (_context.Chanteur == null)
          {
              return Problem("Entity set 'SiteWeb_ISNContext.Chanteur'  is null.");
          }
            _context.Chanteur.Add(chanteur);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChanteur", new { id = chanteur.IdChanteur }, chanteur);
        }

        // DELETE: api/Chanteurs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChanteur(int id)
        {
            if (_context.Chanteur == null)
            {
                return NotFound();
            }
            var chanteur = await _context.Chanteur.FindAsync(id);
            if (chanteur == null)
            {
                return NotFound();
            }

            _context.Chanteur.Remove(chanteur);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChanteurExists(int id)
        {
            return (_context.Chanteur?.Any(e => e.IdChanteur == id)).GetValueOrDefault();
        }
    }
}
