using Microsoft.AspNetCore.Mvc;
using APIWeb_ISN.Models;
using System.Collections.Generic;
using System.Linq;

namespace APIWeb_ISN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly List<Movies> _movies = new List<Movies>
        {
            new Movies { IdFilm = 1, NomFilm = "Interstellar", Duree = "2h 49m", image = "https://images.app.goo.gl/XyMbtd5bR8gnvMJ97", description = "Set in a dystopian future where humanity is embroiled in a catastrophic blight and famine, the film follows a group of astronauts who travel through a wormhole near Saturn in search of a new home for humankind." }
        };

        // GET: api/Movies
        [HttpGet]
        public ActionResult<IEnumerable<Movies>> GetMovies()
        {
            return _movies;
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public ActionResult<Movies> GetMovie(int id)
        {
            var movie = _movies.FirstOrDefault(m => m.IdFilm == id);
            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        // POST: api/Movies
        [HttpPost]
        public ActionResult<Movies> PostMovie(Movies movie)
        {
            _movies.Add(movie);
            return CreatedAtAction(nameof(GetMovie), new { id = movie.IdFilm }, movie);
        }

        // PUT: api/Movies/5
        [HttpPut("{id}")]
        public IActionResult PutMovie(int id, Movies movie)
        {
            if (id != movie.IdFilm)
            {
                return BadRequest();
            }

            var existingMovie = _movies.FirstOrDefault(m => m.IdFilm == id);
            if (existingMovie == null)
            {
                return NotFound();
            }

            existingMovie.NomFilm = movie.NomFilm;
            existingMovie.Duree = movie.Duree;
            existingMovie.image = movie.image;
            existingMovie.description = movie.description;

            return NoContent();
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var movieToRemove = _movies.FirstOrDefault(m => m.IdFilm == id);
            if (movieToRemove == null)
            {
                return NotFound();
            }

            _movies.Remove(movieToRemove);

            return NoContent();
        }
    }
}
