using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lib1.Data;
using Lib1.Models;

namespace lib1.Controllers
{
    public class OverduesController : Controller
    {
        private readonly Lib1DbContext _context;

        public OverduesController(Lib1DbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var Lib1DbContext = _context.Rentals // (b => b.RentalDate.AddDays(30) < DateTime.Now)
                .Include(b => b.Inventory)
                .ThenInclude(b => b.Book) // .ThenInclude (b => b.Book).
                .Include(b => b.Member).Where(b => b.ReturnDate == null);
            return View(await Lib1DbContext.ToListAsync());
        }

        //var Lib1DbContext = await _context.Rentals.Where(b => b.ReturnDate == null)
        //  .Include(borrowing => borrowing.Inventory) //Skickar relevant information vid begäran.
        //              .ThenInclude(inventory => inventory.Book)
        //              .ThenInclude(book => book.BookAuthors)
        //              .ThenInclude(bookAuthor => bookAuthor.Author).ToListAsync(); }
    }
}
// b.ReturnDate
// var Lib1DbContext = await _context.Rentals.Where(b => b.ReturnDate == null)
//   .Include(borrowing => borrowing.Inventory) //Skickar relevant information vid begäran.
//               .ThenInclude(inventory => inventory.Book)
//               .ThenInclude(book => book.BookAuthors)
//               .ThenInclude(bookAuthor => bookAuthor.Author).ToListAsync(); 