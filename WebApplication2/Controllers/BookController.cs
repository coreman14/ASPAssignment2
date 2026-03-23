using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
using WebApplication2.Repositories;


/*
Book controller logic done. View implementation are next. Then copy paste
1. Implement Books, Reader, borrowing Views:
    5 Method conversion - 2 Straight forward (View one and all), 3 new get routes to serve forms and buttons for each action
    - View All - Show each entry with view (Clicking on title), edit and delete buttons
    - View One - Have edit and delete buttons
    - Edit one
    - Create one
    - Delete page (Just say it's been deleted and show link to index)

2a. Layout conversion plus add layout to each view
2b. Edit buttons/links to make sense. 


*Avoid auth stuff, "fake" (login wroks but no actually backend code)

3. New pages
    - Login page -> New LoginController (User Repo)
    - Regi page -> New RegiController (User Repo)
    - Dashboard -> New Dashboard controller (All 3 models controller)

*/


namespace WebApplication2.Controllers
{
    public class BookController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View(BookRepository.GetAll());
        }

        public async Task<IActionResult> Book(int id)
        {
            var x = BookRepository.GetById(id);
            if (x == null)
            {
                ViewBag.missType = "Book";
                return View("miss");
            }
            return View(x);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                BookRepository.Create(book);
                return RedirectToAction("Index");
            }
            return View(book);//Return back to Create page if invalid
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, Book book)
        {
            book.ID = id;
            if (ModelState.IsValid)
            {
                BookRepository.Update(book);
                return RedirectToAction("Index");
            }
            return View(book);//Return back to Create page if invalid
        }
        public async Task<IActionResult> Update(int id)
        {
            var x = BookRepository.GetById(id);
            if (x == null)
            {
                ViewBag.missType = "Book";
                return View("miss");
            }
            return View(x);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var x = BookRepository.GetById(id);
            if (x == null)
            {
                ViewBag.missType = "Book";
                return View("miss");
            }
            BookRepository.Delete(id);
            return View(x);
        }
    }
}
