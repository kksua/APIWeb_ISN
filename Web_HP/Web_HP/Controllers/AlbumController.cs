using Microsoft.AspNetCore.Mvc;

namespace Web_HP.Controllers
{
    public class AlbumController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var api = API.Instance;
            var albums = await api.GetAlbums();
            return View(albums);
        }
    }
}
