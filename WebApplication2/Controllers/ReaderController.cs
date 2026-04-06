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
        private readonly ReaderRepository _readerRepository;

        public ReaderController(ReaderRepository readerRepository)
        {
            _readerRepository = readerRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(_readerRepository.GetAll());
        }
        
        public async Task<IActionResult> Search([FromQuery]string searchstring)
        {
            ViewBag.results = null;
            IEnumerable<Reader>? r = string.IsNullOrEmpty(searchstring) ? null : _readerRepository.GetQuery(searchstring);
            if (r == null || !r.Any())
            {
                r = null;
            }
            else
            {
                int rc = r.Count();
                ViewBag.results = $"Found {rc} reader{(rc == 1 ? "" : "s")} for {searchstring}";
            }
            return View(r);
        }

        public async Task<IActionResult> Reader(int id)
        {
            var x = _readerRepository.GetById(id);
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
                _readerRepository.Create(reader);
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
                _readerRepository.Update(reader);
                return RedirectToAction("Index");
            }
            return View(reader);//Return back to Create page if invalid
        }
        public async Task<IActionResult> Update(int id)
        {
            var x = _readerRepository.GetById(id);
            if (x == null)
            {
                ViewBag.missType = "Reader";
                return View("miss");
            }
            return View(x);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var x = _readerRepository.GetById(id);
            if (x == null)
            {
                ViewBag.missType = "Reader";
                return View("miss");
            }
            _readerRepository.Delete(id);
            return View(x);
        }
    }
}
