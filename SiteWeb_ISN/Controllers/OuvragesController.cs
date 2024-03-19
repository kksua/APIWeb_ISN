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
    public class OuvragesController : ControllerBase
    {
        private readonly APIWeb_ISNContext _context;

        public OuvragesController(APIWeb_ISNContext context)
        {
            _context = context;
        }

        // GET: api/Ouvrages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ouvrage>>> GetOuvrage()
        {
          if (_context.Ouvrage == null)
          {
              return NotFound();
          }
            return await _context.Ouvrage.ToListAsync();
        }

        // GET: api/Ouvrages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ouvrage>> GetOuvrage(int id)
        {
          if (_context.Ouvrage == null)
          {
              return NotFound();
          }
            var ouvrage = await _context.Ouvrage.FindAsync(id);

            if (ouvrage == null)
            {
                return NotFound();
            }

            return ouvrage;
        }

        // PUT: api/Ouvrages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOuvrage(int id, Ouvrage ouvrage)
        {
            if (id != ouvrage.IdOuvrage)
            {
                return BadRequest();
            }

            _context.Entry(ouvrage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OuvrageExists(id))
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

        // POST: api/Ouvrages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ouvrage>> PostOuvrage(Ouvrage ouvrage)
        {
          if (_context.Ouvrage == null)
          {
              return Problem("Entity set 'APIWeb_ISNContext.Ouvrage'  is null.");
          }
            _context.Ouvrage.Add(ouvrage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOuvrage", new { id = ouvrage.IdOuvrage }, ouvrage);
        }

        // DELETE: api/Ouvrages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOuvrage(int id)
        {
            if (_context.Ouvrage == null)
            {
                return NotFound();
            }
            var ouvrage = await _context.Ouvrage.FindAsync(id);
            if (ouvrage == null)
            {
                return NotFound();
            }

            _context.Ouvrage.Remove(ouvrage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OuvrageExists(int id)
        {
            return (_context.Ouvrage?.Any(e => e.IdOuvrage == id)).GetValueOrDefault();
        }
    }
}
