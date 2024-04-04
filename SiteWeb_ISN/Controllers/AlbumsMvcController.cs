using Microsoft.AspNetCore.Mvc;
using APIWeb_ISN.Models;
using System.Collections.Generic;
using System.Linq;

namespace APIWeb_ISN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly List<Album> _albums = new List<Album>
        {
            new Album { IdAlbum = 1, NomAlbum = "WHITE NIGHT", Image = "https://images.app.goo.gl/b9mmb5RELd9yEGno6" },
            new Album { IdAlbum = 2, NomAlbum = "SEVENTEEN 11th Mini Album 'SEVENTEENTH HEAVEN'", Image = "https://i.scdn.co/image/ab67616d0000b273d07a54abba4f5060c2486e3c" }
        };

        // GET: api/Album
        [HttpGet]
        public ActionResult<IEnumerable<Album>> GetAlbums()
        {
            return _albums;
        }

        // GET: api/Album/5
        [HttpGet("{id}")]
        public ActionResult<Album> GetAlbum(int id)
        {
            var album = _albums.FirstOrDefault(a => a.IdAlbum == id);
            if (album == null)
            {
                return NotFound();
            }

            return album;
        }

        // POST: api/Album
        [HttpPost]
        public ActionResult<Album> PostAlbum(Album album)
        {
            _albums.Add(album);
            return CreatedAtAction(nameof(GetAlbum), new { id = album.IdAlbum }, album);
        }

        // PUT: api/Album/5
        [HttpPut("{id}")]
        public IActionResult PutAlbum(int id, Album album)
        {
            if (id != album.IdAlbum)
            {
                return BadRequest();
            }

            var existingAlbum = _albums.FirstOrDefault(a => a.IdAlbum == id);
            if (existingAlbum == null)
            {
                return NotFound();
            }

            existingAlbum.NomAlbum = album.NomAlbum;
            existingAlbum.Image = album.Image;

            return NoContent();
        }

        // DELETE: api/Album/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAlbum(int id)
        {
            var albumToRemove = _albums.FirstOrDefault(a => a.IdAlbum == id);
            if (albumToRemove == null)
            {
                return NotFound();
            }

            _albums.Remove(albumToRemove);

            return NoContent();
        }
    }
}
