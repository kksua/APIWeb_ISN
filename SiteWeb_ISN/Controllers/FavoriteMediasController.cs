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
    public class FavoriteMediasController : ControllerBase
    {
        private readonly APIWeb_ISNContext _context;

        public FavoriteMediasController(APIWeb_ISNContext context)
        {
            _context = context;
        }

        // GET: api/FavoriteMedias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FavoriteMedia>>> GetFavoriteMedia()
        {
          if (_context.FavoriteMedia == null)
          {
              return NotFound();
          }
            return await _context.FavoriteMedia.ToListAsync();
        }

        // GET: api/FavoriteMedias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FavoriteMedia>> GetFavoriteMedia(int id)
        {
          if (_context.FavoriteMedia == null)
          {
              return NotFound();
          }
            var favoriteMedia = await _context.FavoriteMedia.FindAsync(id);

            if (favoriteMedia == null)
            {
                return NotFound();
            }

            return favoriteMedia;
        }

        // PUT: api/FavoriteMedias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavoriteMedia(int id, FavoriteMedia favoriteMedia)
        {
            if (id != favoriteMedia.Id)
            {
                return BadRequest();
            }

            _context.Entry(favoriteMedia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavoriteMediaExists(id))
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

        // POST: api/FavoriteMedias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FavoriteMedia>> PostFavoriteMedia(FavoriteMedia favoriteMedia)
        {
          if (_context.FavoriteMedia == null)
          {
              return Problem("Entity set 'APIWeb_ISNContext.FavoriteMedia'  is null.");
          }
            _context.FavoriteMedia.Add(favoriteMedia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFavoriteMedia", new { id = favoriteMedia.Id }, favoriteMedia);
        }

        // DELETE: api/FavoriteMedias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavoriteMedia(int id)
        {
            if (_context.FavoriteMedia == null)
            {
                return NotFound();
            }
            var favoriteMedia = await _context.FavoriteMedia.FindAsync(id);
            if (favoriteMedia == null)
            {
                return NotFound();
            }

            _context.FavoriteMedia.Remove(favoriteMedia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FavoriteMediaExists(int id)
        {
            return (_context.FavoriteMedia?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
