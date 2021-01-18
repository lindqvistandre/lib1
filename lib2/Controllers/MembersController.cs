using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lib2.Data;
using Lib2.Models;     

namespace lib2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly Lib2DbContext _context;

        public MembersController(Lib2DbContext context)
        {
            _context = context;
        }

        // GET: api/Members
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member>>> GetMembers()
        {
            return await _context.Members.ToListAsync();
        }

        // GET: api/Members/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Member>> GetMember(int id)
        {
            var member = await _context.Members.FindAsync(id);

            if (member == null)
            {
                return NotFound();
            }

            return member;
        }

        // PUT: api/members/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMember(int id, Member member)
        {
            if (id != member.MemberId)
            {
                return BadRequest();
            }

            _context.Entry(member).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Members
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Member>> PostMember(Member member)
        {
            _context.Members.Add(member);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMember", new { id = member.MemberId }, member);
        }

        // DELETE: api/Members/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Member>> DeleteMember(int id)
        {
            var member = await _context.Members.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }

            _context.Members.Remove(member);
            await _context.SaveChangesAsync();

            return member;
        }

        // POST: api/members/5/rentBook/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("{memberId}/rentBook/{bookId}")]
        public async Task<ActionResult<Member>> RentBook(int memberId, int bookId)
        {
            var member = await _context.Members
                .SingleOrDefaultAsync(c => c.MemberId == memberId);

            if (member == null)
            {
                return BadRequest("Member does not exist!");
            }

            // get inventory for the bookId
            // include on book to get the title
            // include on Rentals to check availability
            var inventory = await _context.Inventory
                .Include(i => i.Book)
                .Include(i => i.Rentals)
                .Where(i => i.BookId == bookId)
                .ToListAsync();

            // check if any of them are available
            var availableInv = inventory.FirstOrDefault(i => i.Available);

            if (availableInv == null)
            {
                return BadRequest("Book not avabilable for renting!");
            }

            var rental = new Rental()
            {
                MemberId = memberId,
                InventoryId = availableInv.InventoryId,
                RentalDate = DateTime.Now,

               // ReturnDate = DateTime.Now.AddDays(30)     lägger till att returndate är 30dagar senare auto.

               // ReturnDate = DateTime.Now.AddDays(30)


            };

            _context.Rentals.Add(rental);
            await _context.SaveChangesAsync();

            return Ok($"Member {member.FirstName} rented the book {availableInv.Book.Title} at {rental.RentalDate}");
        }

        // POST: api/Members/5/returnBook/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("{memberId}/returnBook/{bookId}")]
        public async Task<ActionResult<Member>> ReturnBook(int memberId, int bookId)
        {
            // Hämtar kunden och alla dens lån.
            var member = await _context.Members
                .Include(c => c.Rentals)
                .ThenInclude(r => r.Inventory)
                .ThenInclude(i => i.Book)
                .SingleOrDefaultAsync(c => c.MemberId == memberId);

            if (member == null)
            {
                return BadRequest("Member does not exist!");
            }

            if (member.Rentals == null || member.Rentals.Count == 0)
            {
                return BadRequest("Member does not have any rentals!");
            }

            // kolla om kunden har hyrt booken med detta id.
            var rental = member.Rentals.FirstOrDefault(r => r.Inventory.BookId == bookId && !r.Returned);

            if (rental == null)
            {
                return BadRequest("Member have not rented this book.");
            }

            // har vi kommit hit så har kunden hyrt booken och den återlämnas genom att sätta returnDate
            _context.Entry(rental).State = EntityState.Modified;
            rental.ReturnDate = DateTime.Now;

            await _context.SaveChangesAsync();

            return Ok($"Member {member.FirstName} return the book {rental.Inventory.Book.Title} at {rental.RentalDate}");
        }

        private bool MemberExists(int id)
        {
            return _context.Members.Any(e => e.MemberId == id);
        }
    }
}
