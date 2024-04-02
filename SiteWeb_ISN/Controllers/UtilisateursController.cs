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
        // GET: api/Utilisateurs/5
        [HttpGet("{login}/{password}")]
        public async Task<ActionResult<Utilisateur>> VerifyLogin(string login, string pwd)
        {
            if (_context.Utilisateur == null)
            {
                return NotFound();
            }
            //var utilisateur = await _context.Utilisateur.FindAsync(id);
            var existingUser = await _context.Utilisateur.FirstOrDefaultAsync(u => u.NomUser == login && u.MDP == pwd);

            if (existingUser == null)
            {
                return NotFound();
            }

            return existingUser;
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

        // POST: api/Utilisateurs/Login
        [HttpPost("Login")] // Définissez un nouveau point de terminaison pour la connexion
        public async Task<ActionResult<Utilisateur>> Login(Utilisateur utilisateur)
        {
            // Vérifie si l'ensemble d'entités Utilisateur est nul
            if (_context.Utilisateur == null)
            {
                // Renvoie un problème avec un message d'erreur
                return Problem("L'ensemble d'entités 'APIWeb_ISNContext.Utilisateur' est nul.");
            }

            // Vérifie si le nom d'utilisateur et le mot de passe fournis correspondent à un utilisateur existant
            var existingUser = await _context.Utilisateur.FirstOrDefaultAsync(u => u.NomUser == utilisateur.NomUser && u.MDP == utilisateur.MDP);

            // Si un utilisateur correspondant est trouvé
            if (existingUser != null)
            {
                // Connexion réussie, renvoie les détails de l'utilisateur existant
                return Ok(existingUser);
            }
            else
            {
                // Échec de la connexion, renvoie un message indiquant que le nom d'utilisateur ou le mot de passe est invalide
                return NotFound("Nom d'utilisateur ou mot de passe incorrect");
            }
        }
    }
}
