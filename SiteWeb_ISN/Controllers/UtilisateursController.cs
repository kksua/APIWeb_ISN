﻿using System;
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
    public class UtilisateursController : ControllerBase
    {
        private readonly APIWeb_ISNContext _context;

        public UtilisateursController(APIWeb_ISNContext context)
        {
            _context = context;
        }

        // GET: api/Utilisateurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Utilisateur>>> GetUtilisateur()
        {
          if (_context.Utilisateur == null)
          {
              return NotFound();
          }
            return await _context.Utilisateur.ToListAsync();
        }

        // GET: api/Utilisateurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Utilisateur>> GetUtilisateur(int id)
        {
          if (_context.Utilisateur == null)
          {
              return NotFound();
          }
            var utilisateur = await _context.Utilisateur.FindAsync(id);

            if (utilisateur == null)
            {
                return NotFound();
            }

            return utilisateur;
        }

        // PUT: api/Utilisateurs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUtilisateur(int id, Utilisateur utilisateur)
        {
            if (id != utilisateur.IdUtilisateur)
            {
                return BadRequest();
            }

            _context.Entry(utilisateur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UtilisateurExists(id))
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

        // POST: api/Utilisateurs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Utilisateur>> PostUtilisateur(Utilisateur utilisateur)
        {
          if (_context.Utilisateur == null)
          {
              return Problem("Entity set 'APIWeb_ISNContext.Utilisateur'  is null.");
          }
            _context.Utilisateur.Add(utilisateur);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUtilisateur", new { id = utilisateur.IdUtilisateur }, utilisateur);
        }

        // DELETE: api/Utilisateurs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUtilisateur(int id)
        {
            if (_context.Utilisateur == null)
            {
                return NotFound();
            }
            var utilisateur = await _context.Utilisateur.FindAsync(id);
            if (utilisateur == null)
            {
                return NotFound();
            }

            _context.Utilisateur.Remove(utilisateur);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UtilisateurExists(int id)
        {
            return (_context.Utilisateur?.Any(e => e.IdUtilisateur == id)).GetValueOrDefault();
        }
    }
}
