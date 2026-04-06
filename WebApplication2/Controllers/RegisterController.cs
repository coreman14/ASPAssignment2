using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Repositories;

namespace WebApplication2.Controllers
{
    public class RegisterController : Controller
    {
        private readonly AppUserRepository _appUserRepository;

        public RegisterController(AppUserRepository appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Register(AppUser user)
        {

        if (ModelState.IsValid)
        {
            _appUserRepository.Create(user);
            return RedirectToAction("Index", "Login");
        }
        return View("index");//Return back login
        }
    }
}
