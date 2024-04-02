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
        [HttpPost]
        public ActionResult Index(UserViewModel viewModel)
        {
            //if (ModelState.IsValid)
            {
                Utilisateur utilisateur = API.Instance.GetUser(viewModel.Utilisateur.Email, viewModel.Utilisateur.MDP).Result;
                if (utilisateur != null)
                {
                    return Redirect("/Home/Index");
                }
                ModelState.AddModelError("Utilisateur.Login", "Login et/ou mot de passe incorrect(s)");
            }
            return View(viewModel);
        }

        public ActionResult Deconnexion()
        {
            return Redirect("/");
        }
    }
}
