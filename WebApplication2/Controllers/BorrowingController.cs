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

    /*
    Procrastinated too long, cant finish tonight
    This is hte first thing we do when we get home tomorrow no buts
    1. Login/Register page
    2. Dashboard showing all 3 models using the same thing as view.
    3. Redo layout buttons - I dont think we need to touch else

    */
    public class BorrowingController : Controller
    {
        private readonly BorrowingRepository _borrowingRepository;
        private readonly ReaderRepository _readerRepository;
        private readonly BookRepository _bookRepository;

        public BorrowingController(
            BorrowingRepository borrowingRepository,
            ReaderRepository readerRepository,
            BookRepository bookRepository)
        {
            _borrowingRepository = borrowingRepository;
            _readerRepository = readerRepository;
            _bookRepository = bookRepository;
        }

        private void PopulateDropdowns(int? selectedBookId = null, int? selectedReaderId = null)
        {
            var readerValues = _readerRepository.GetAll().Select(x => new DropdownDto
            {
                Name = x.Name + " - " + x.Email,
                Value = x.ID + "",
                Selected = selectedReaderId.HasValue && x.ID == selectedReaderId.Value
            }).ToList();

            var bookValues = _bookRepository.GetAll().Where(x => x.IsAvailable || (selectedBookId.HasValue && x.ID == selectedBookId.Value))
            .Select(x => new DropdownDto
            {
                Name = x.ID + " - " + x.Title + " - " + x.Author,
                Value = x.ID + "",
                Selected = selectedBookId.HasValue && x.ID == selectedBookId.Value
            }).ToList();

            ViewBag.BookValues = bookValues;
            ViewBag.ReaderValues = readerValues;
        }

        public async Task<IActionResult> Index()
        {
            return View(_borrowingRepository.GetAll());
        }

        public async Task<IActionResult> Search([FromQuery]string searchstring)
        {
            ViewBag.results = null;
            IEnumerable<Borrowing>? r = string.IsNullOrEmpty(searchstring) ? null : _borrowingRepository.GetQuery(searchstring);
            if (r == null || !r.Any())
            {
                r = null;
            }
            else
            {
                int rc = r.Count();
                ViewBag.results = $"Found {rc} borrowing{(rc == 1 ? "" : "s")} for {searchstring}";
            }
            return View(r);
        }
        public async Task<IActionResult> Borrowing(int id)
        {
            var x = _borrowingRepository.GetById(id);
            if (x == null)
            {
                ViewBag.missType = "Borrowing";
                return View("miss");
            }
            return View(x);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Borrowing borrowing)
        {
            if (_bookRepository.IdExist(borrowing.BookId) && _readerRepository.IdExist(borrowing.ReaderId) && ModelState.IsValid)
            {
                _borrowingRepository.Create(borrowing);
                return RedirectToAction("Index");
            }
            PopulateDropdowns(borrowing.BookId, borrowing.ReaderId);
            return View(borrowing);//Return back to Create page if invalid
        }
        public async Task<IActionResult> Create()
        {
            PopulateDropdowns();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, Borrowing borrowing)
        {
            if (_bookRepository.IdExist(borrowing.BookId) && _readerRepository.IdExist(borrowing.ReaderId) && ModelState.IsValid)
            {
                borrowing.ID = id;
                _borrowingRepository.Update(borrowing);
                return RedirectToAction("Index");
            }
            borrowing.ID = id;
            PopulateDropdowns(borrowing.BookId, borrowing.ReaderId);
            return View(borrowing);//Return back to Create page if invalid
        }
        public async Task<IActionResult> Update(int id)
        {
            var x = _borrowingRepository.GetById(id);
            if (x == null)
            {
                ViewBag.missType = "Borrowing";
                return View("miss");
            }
            PopulateDropdowns(x.BookId, x.ReaderId);
            return View(x);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var x = _borrowingRepository.GetById(id);
            if (x == null)
            {
                ViewBag.missType = "Borrowing";
                return View("miss");
            }
            _borrowingRepository.Delete(id);
            return View(x);
        }
    }
}
