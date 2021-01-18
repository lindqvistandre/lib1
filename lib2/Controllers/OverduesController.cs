using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lib2.Data;
using Lib2.Models;

namespace lib2.Controllers
{
    public class OverduesController : Controller
    {
        private readonly Lib2DbContext _context;

        public OverduesController(Lib2DbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            //var Lib2DbContext = _context.Rentals // (b => b.RentalDate.AddDays(30) < DateTime.Now)
            //    .Include(b => b.Inventory)
            //    .ThenInclude(b => b.Book) // .ThenInclude (b => b.Book).
            //    .Include(b => b.Member).Where(b => b.ReturnDate == null);
            //return View(await Lib2DbContext.ToListAsync());
            //}

            var Lib2DbContext = await _context.Rentals.Where(b => b.ReturnDate == null)
              .Include(borrowing => borrowing.Inventory) //Skickar relevant information vid begäran.
                          .ThenInclude(inventory => inventory.Book)
                          .ThenInclude(book => book.BookAuthors)
                          .ThenInclude(bookAuthor => bookAuthor.Author).ToListAsync();
        }
    }
}
}
// b.ReturnDate
// var Lib2DbContext = await _context.Rentals.Where(b => b.ReturnDate == null)
//   .Include(borrowing => borrowing.Inventory) //Skickar relevant information vid begäran.
//               .ThenInclude(inventory => inventory.Book)
//               .ThenInclude(book => book.BookAuthors)
//               .ThenInclude(bookAuthor => bookAuthor.Author).ToListAsync(); 