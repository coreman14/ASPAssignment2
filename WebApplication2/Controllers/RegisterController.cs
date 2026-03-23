using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Repositories;

namespace WebApplication2.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Register(AppUser user)
        {

        if (ModelState.IsValid)
        {
            AppUserRepository.Create(user);
            return RedirectToAction("Index", "Login");
        }
        return View("index");//Return back login
        }
    }
}
