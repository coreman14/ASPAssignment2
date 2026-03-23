using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Repositories;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private void PopulateTables()
        {
            var readerValues = ReaderRepository.GetAll();
            var bookValues = BookRepository.GetAll();
            var borrowingValues = BorrowingRepository.GetAll();

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
