using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Repositories;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ReaderRepository _readerRepository;
        private readonly BookRepository _bookRepository;
        private readonly BorrowingRepository _borrowingRepository;

        public HomeController(
            ReaderRepository readerRepository,
            BookRepository bookRepository,
            BorrowingRepository borrowingRepository)
        {
            _readerRepository = readerRepository;
            _bookRepository = bookRepository;
            _borrowingRepository = borrowingRepository;
        }

        private void PopulateTables()
        {
            var readerValues = _readerRepository.GetAll();
            var bookValues = _bookRepository.GetAll();
            var borrowingValues = _borrowingRepository.GetAll();

            ViewBag.BookValues = bookValues;
            ViewBag.ReaderValues = readerValues;
            ViewBag.BorrowingValues = borrowingValues.Select((x) => new BorrowingDto
            {
                ID = x.ID,
                BookId = x.BookId,
                BookName = bookValues.First((y) => y.ID == x.BookId).Title,
                ReaderId = x.ReaderId,
                ReaderName = readerValues.First((y) => y.ID == x.ReaderId).Name,
                BorrowedDate = x.BorrowedDate,
                IsReturned = x.IsReturned,
                LastDate = (DateTime)(x.IsReturned ? x.ReturnedDate : x.BorrowedDate.AddHours(24 * x.DaysToBorrow)),
            });
        }
        public IActionResult Index()
        {
            PopulateTables();
            return View();
        }
    }
}
