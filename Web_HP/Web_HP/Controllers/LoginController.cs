using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_HP.Models;
using Web_HP.ViewModel;
using APIWeb_ISN.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace Web_HP.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            UserViewModel viewModel = new UserViewModel {  };
            //if (HttpContext.User.Identity.IsAuthenticated)
            //{
            //    viewModel.User = API.Instance.GetUser(HttpContext.User.Identity.Name).Result;
            //}
            //else
            //{
            //    HttpContext.User.Identity.;
            //}
            return View(viewModel);
        }
        public IActionResult Home2()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(UserViewModel viewModel)
        {
            if (viewModel.Utilisateur != null)
            {
#pragma warning disable CS8604 // Existence possible d'un argument de référence null.
                Utilisateur utilisateur = await API.Instance.VerifyLogin(viewModel.Utilisateur.Email, viewModel.Utilisateur.MDP);
#pragma warning restore CS8604 // Existence possible d'un argument de référence null.
                if (utilisateur != null)
                {
                    ViewBag.WelcomeMessage = $"Welcome, {utilisateur.NomUser}!";
                    // Redirect to HomeController's Index action
                    return RedirectToAction("Home2", "Login");
                }
                ModelState.AddModelError("Utilisateur.Email", "Email et/ou mot de passe incorrect(s)");
            }
            else
            {
                ModelState.AddModelError("Utilisateur", "Utilisateur est null");
            }
            return View(viewModel);
        }

    }
}
