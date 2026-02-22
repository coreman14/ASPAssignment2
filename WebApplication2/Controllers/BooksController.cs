using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class BookController : Controller
    {

        public BookController()
        {
        }

        public async Task<Book[]> Index()
        {
            return [];
        }

        public async Task<Book> Book(int? id)
        {
            return new Book
            {
                ID = id.GetValueOrDefault(1),
                Title = "",
                Author = "",
                IBSN = "Your ISBN has to be valid, but I dont have to follow the rules",
            };
        }
        [HttpPost]
        public async Task<Book> Create(Book book)
        {
            return new Book
            {
                Title = "",
                Author = "",
                IBSN = "Your ISBN has to be valid, but I dont have to follow the rules",
            };
        }
        [HttpPut]
        public async Task<Book> Update(int? id, Book book)
        {
            
            return new Book
            {
                ID = id.GetValueOrDefault(1),
                Title = "",
                Author = "",
                IBSN = "Your ISBN has to be valid, but I dont have to follow the rules",
            };
        }
        [HttpDelete]
        public async Task<Book> Delete(int? id)
        {
            return new Book
            {
                ID = id.GetValueOrDefault(1),
                Title = "",
                Author = "",
                IBSN = "Your ISBN has to be valid, but I dont have to follow the rules",
            };
        }

    }
}
