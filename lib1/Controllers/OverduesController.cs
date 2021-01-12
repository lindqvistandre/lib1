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

        public async Task<IActionResult> Index() { 
            var Lib1DbContext = _context.Rentals.Where(b => b.ReturnDate < DateTime.Now).Include(b => b.Book).Include(b => b.Member); 
            return View(await Lib1DbContext.ToListAsync()); }

    }
}
