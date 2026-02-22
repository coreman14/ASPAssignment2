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
    public class ReaderController : Controller
    {

        public ReaderController()
        {
        }

        public async Task<Reader[]> Index()
        {
            return [];
        }

        public async Task<Reader> Reader(int? id)
        {
            return new Reader
            {
                ID = id.GetValueOrDefault(1),
                Email = "Same thing",
                Name = "Ha"
            };
        }
        [HttpPost]
        public async Task<Reader> Create(Reader reader)
        {
            return new Reader
            {
                Email = "Same thing",
                Name = "Ha"
            };
        }
        [HttpPut]
        public async Task<Reader> Update(int? id, Reader reader)
        {
            return new Reader
            {
                ID = id.GetValueOrDefault(1),
                Email = "Same thing",
                Name = "Ha"
            };
        }
        [HttpDelete]
        public async Task<Reader> Delete(int? id)
        {
            return new Reader
            {
                ID = id.GetValueOrDefault(1),
                Email = "Same thing",
                Name = "Ha"
            };
        }

    }
}
