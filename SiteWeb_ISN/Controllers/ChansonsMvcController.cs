using Microsoft.AspNetCore.Mvc;
using APIWeb_ISN.Models;
using System.Collections.Generic;
using System.Linq;

namespace APIWeb_ISN.Controllers
{
    [Route("api/Chanson")]
    [ApiController]
    public class ChansonController : ControllerBase
    {
        private readonly List<Chanson> _chansons = new List<Chanson>
        {
            new Chanson { IdChanson = 1, NomChanson = "Blanche nuit", Genre = "jazz", Langue = "chinois", Image = "https://wx4.sinaimg.cn/mw690/008lgPsGgy1hm7ywqg5wij31hc140nca.jpg", Lien = "https://youtu.be/KOa-FlZ3EyI?si=5VqUKZnJYnXzGXr1" },
            new Chanson { IdChanson = 2, NomChanson = "God of Music", Genre = "happy", Langue = "coréen", Image = "https://i.scdn.co/image/ab67616d0000b273d07a54abba4f5060c2486e3c", Lien = "https://youtu.be/zSQ48zyWZrY?si=n-VvhGBwkcSTFBAc" }
        };

        // GET: api/Chanson
        [HttpGet]
        public ActionResult<IEnumerable<Chanson>> GetChansons()
        {
            return _chansons;
        }

        // GET: api/Chanson/5
        [HttpGet("{id}")]
        public ActionResult<Chanson> GetChanson(int id)
        {
            var chanson = _chansons.FirstOrDefault(c => c.IdChanson == id);
            if (chanson == null)
            {
                return NotFound();
            }

            return chanson;
        }

        // POST: api/Chanson
        [HttpPost]
        public ActionResult<Chanson> PostChanson(Chanson chanson)
        {
            _chansons.Add(chanson);
            return CreatedAtAction(nameof(GetChanson), new { id = chanson.IdChanson }, chanson);
        }

        // PUT: api/Chanson/5
        [HttpPut("{id}")]
        public IActionResult PutChanson(int id, Chanson chanson)
        {
            if (id != chanson.IdChanson)
            {
                return BadRequest();
            }

            var existingChanson = _chansons.FirstOrDefault(c => c.IdChanson == id);
            if (existingChanson == null)
            {
                return NotFound();
            }

            existingChanson.NomChanson = chanson.NomChanson;
            existingChanson.Genre = chanson.Genre;
            existingChanson.Langue = chanson.Langue;
            existingChanson.Image = chanson.Image;
            existingChanson.Lien = chanson.Lien;

            return NoContent();
        }

        // DELETE: api/Chanson/5
        [HttpDelete("{id}")]
        public IActionResult DeleteChanson(int id)
        {
            var chansonToRemove = _chansons.FirstOrDefault(c => c.IdChanson == id);
            if (chansonToRemove == null)
            {
                return NotFound();
            }

            _chansons.Remove(chansonToRemove);

            return NoContent();
        }
    }
}
