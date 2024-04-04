using Microsoft.AspNetCore.Mvc;
using APIWeb_ISN.Models;
using System.Collections.Generic;
using System.Linq;

namespace APIWeb_ISN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SerieController : ControllerBase
    {
        private readonly List<Series> _series = new List<Series>
        {
            new Series { IdSeries = 1, NomSerie = "Nirvana in Fire", NmbreSeasons = 2, NmbreEpisode = 54 }
        };

        // GET: api/Series
        [HttpGet]
        public ActionResult<IEnumerable<Series>> GetSeries()
        {
            return _series;
        }

        // GET: api/Series/5
        [HttpGet("{id}")]
        public ActionResult<Series> GetSerie(int id)
        {
            var serie = _series.FirstOrDefault(s => s.IdSeries == id);
            if (serie == null)
            {
                return NotFound();
            }

            return serie;
        }

        // POST: api/Series
        [HttpPost]
        public ActionResult<Series> PostSerie(Series serie)
        {
            _series.Add(serie);
            return CreatedAtAction(nameof(GetSerie), new { id = serie.IdSeries }, serie);
        }

        // PUT: api/Series/5
        [HttpPut("{id}")]
        public IActionResult PutSerie(int id, Series serie)
        {
            if (id != serie.IdSeries)
            {
                return BadRequest();
            }

            var existingSerie = _series.FirstOrDefault(s => s.IdSeries == id);
            if (existingSerie == null)
            {
                return NotFound();
            }

            existingSerie.NomSerie = serie.NomSerie;
            existingSerie.NmbreSeasons = serie.NmbreSeasons;
            existingSerie.NmbreEpisode = serie.NmbreEpisode;

            return NoContent();
        }

        // DELETE: api/Series/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSerie(int id)
        {
            var serieToRemove = _series.FirstOrDefault(s => s.IdSeries == id);
            if (serieToRemove == null)
            {
                return NotFound();
            }

            _series.Remove(serieToRemove);

            return NoContent();
        }
    }
}
