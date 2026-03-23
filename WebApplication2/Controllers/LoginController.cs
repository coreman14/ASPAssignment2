using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Repositories;

namespace WebApplication2.Controllers
{
    public class LoginController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (AppUserRepository.ValidateCredentials(email, password))
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.error = "Login failed. Please try again";
            return View("index");//Return back login
        }
    }
}
