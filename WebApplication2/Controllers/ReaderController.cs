using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
using WebApplication2.Repositories;

namespace WebApplication2.Controllers
{
    public class ReaderController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View(ReaderRepository.GetAll());
        }

        public async Task<IActionResult> Reader(int id)
        {
            var x = ReaderRepository.GetById(id);
            if (x == null)
            {
                ViewBag.missType = "Reader";
                return View("miss");
            }
            return View(x);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Reader reader)
        {
            if (ModelState.IsValid)
            {
                ReaderRepository.Create(reader);
                return RedirectToAction("Index");
            }
            return View(reader);//Return back to Create page if invalid
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, Reader reader)
        {
            reader.ID = id;
            if (ModelState.IsValid)
            {
                ReaderRepository.Update(reader);
                return RedirectToAction("Index");
            }
            return View(reader);//Return back to Create page if invalid
        }
        public async Task<IActionResult> Update(int id)
        {
            var x = ReaderRepository.GetById(id);
            if (x == null)
            {
                ViewBag.missType = "Reader";
                return View("miss");
            }
            return View(x);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var x = ReaderRepository.GetById(id);
            if (x == null)
            {
                ViewBag.missType = "Reader";
                return View("miss");
            }
            ReaderRepository.Delete(id);
            return View(x);
        }
    }
}
