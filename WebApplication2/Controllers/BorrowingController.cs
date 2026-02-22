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
    public class BorrowingController : Controller
    {

        public BorrowingController()
        {
        }

        public async Task<Borrowing[]> Index()
        {
            return [];
        }

        public async Task<Borrowing> Borrowing(int? id)
        {
            return new Borrowing
            {
                BookId = id.GetValueOrDefault(1),
                ReaderId = id.GetValueOrDefault(1),
                BorrowedDate = new DateTime()
            };
        }
        [HttpPost]
        public async Task<Borrowing> Create(Borrowing borrowing)
        {
            return new Borrowing
            {
                BookId = 1,
                ReaderId = 1,
                BorrowedDate = new DateTime()
            };
        }
        [HttpPut]
        public async Task<Borrowing> Update(int? id, Borrowing borrowing)
        {
            return new Borrowing
            {
                BookId = id.GetValueOrDefault(1),
                ReaderId = id.GetValueOrDefault(1),
                BorrowedDate = new DateTime()
            };
        }
        [HttpDelete]
        public async Task<Borrowing> Delete(int? id)
        {
            return new Borrowing
            {
                BookId = id.GetValueOrDefault(1),
                ReaderId = id.GetValueOrDefault(1),
                BorrowedDate = new DateTime()
            };
        }

    }
}
