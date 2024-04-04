using Microsoft.AspNetCore.Mvc;
using APIWeb_ISN.Models;
using System.Collections.Generic;
using System.Linq;

namespace APIWeb_ISN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChanteurController : ControllerBase
    {
        private readonly List<Chanteur> _chanteurs = new List<Chanteur>
        {
           new Chanteur { IdChanteur = 1, Nom = "ZHANG Jie", nationaliteChanteur = "Chinois", Image = "https://y.qq.com/music/photo_new/T001R300x300M000002azErJ0UcDN6_3.jpg?max_age=2592000" },
            new Chanteur { IdChanteur = 2, Nom = "SEVENTEEN", nationaliteChanteur = "Groupe Coréen", Image = "https://file.krfanyi.com/krfanyi/202110/23/220235621.png" }
        };

        // GET: api/Chanteur
        [HttpGet]
        public ActionResult<IEnumerable<Chanteur>> GetChanteurs()
        {
            return _chanteurs;
        }

        // GET: api/Chanteur/5
        [HttpGet("{id}")]
        public ActionResult<Chanteur> GetChanteur(int id)
        {
            var chanteur = _chanteurs.FirstOrDefault(c => c.IdChanteur == id);
            if (chanteur == null)
            {
                return NotFound();
            }

            return chanteur;
        }

        // POST: api/Chanteur
        [HttpPost]
        public ActionResult<Chanteur> PostChanteur(Chanteur chanteur)
        {
            _chanteurs.Add(chanteur);
            return CreatedAtAction(nameof(GetChanteur), new { id = chanteur.IdChanteur }, chanteur);
        }

        // PUT: api/Chanteur/5
        [HttpPut("{id}")]
        public IActionResult PutChanteur(int id, Chanteur chanteur)
        {
            if (id != chanteur.IdChanteur)
            {
                return BadRequest();
            }

            var existingChanteur = _chanteurs.FirstOrDefault(c => c.IdChanteur == id);
            if (existingChanteur == null)
            {
                return NotFound();
            }

            existingChanteur.Nom = chanteur.Nom;
            existingChanteur.nationaliteChanteur = chanteur.nationaliteChanteur;
            existingChanteur.Image = chanteur.Image;

            return NoContent();
        }

        // DELETE: api/Chanteur/5
        [HttpDelete("{id}")]
        public IActionResult DeleteChanteur(int id)
        {
            var chanteurToRemove = _chanteurs.FirstOrDefault(c => c.IdChanteur == id);
            if (chanteurToRemove == null)
            {
                return NotFound();
            }

            _chanteurs.Remove(chanteurToRemove);

            return NoContent();
        }
    }
}
