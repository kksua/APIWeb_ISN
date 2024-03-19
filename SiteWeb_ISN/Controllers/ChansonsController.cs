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
    public class ChansonsController : ControllerBase
    {
        private readonly APIWeb_ISNContext _context;

        public ChansonsController(APIWeb_ISNContext context)
        {
            _context = context;
        }

        // GET: api/Chansons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chanson>>> GetChanson()
        {
          if (_context.Chanson == null)
          {
              return NotFound();
          }
            return await _context.Chanson.ToListAsync();
        }

        // GET: api/Chansons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Chanson>> GetChanson(int id)
        {
          if (_context.Chanson == null)
          {
              return NotFound();
          }
            var chanson = await _context.Chanson.FindAsync(id);

            if (chanson == null)
            {
                return NotFound();
            }

            return chanson;
        }

        // PUT: api/Chansons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChanson(int id, Chanson chanson)
        {
            if (id != chanson.IdChanson)
            {
                return BadRequest();
            }

            _context.Entry(chanson).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChansonExists(id))
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

        // POST: api/Chansons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Chanson>> PostChanson(Chanson chanson)
        {
          if (_context.Chanson == null)
          {
              return Problem("Entity set 'APIWeb_ISNContext.Chanson'  is null.");
          }
            _context.Chanson.Add(chanson);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChanson", new { id = chanson.IdChanson }, chanson);
        }

        // DELETE: api/Chansons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChanson(int id)
        {
            if (_context.Chanson == null)
            {
                return NotFound();
            }
            var chanson = await _context.Chanson.FindAsync(id);
            if (chanson == null)
            {
                return NotFound();
            }

            _context.Chanson.Remove(chanson);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChansonExists(int id)
        {
            return (_context.Chanson?.Any(e => e.IdChanson == id)).GetValueOrDefault();
        }
    }
}
