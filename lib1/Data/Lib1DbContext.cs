using Lib1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lib1.Data
{
    public class Lib1DbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Rental> Rentals { get; set; }


        public Lib1DbContext(DbContextOptions<Lib1DbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<BookAuthor>()
                .HasKey(sc => new { sc.BookId, sc.AuthorId });

            modelbuilder.Entity<BookAuthor>()
                .HasOne(sc => sc.Book)
                .WithMany(s => s.BookAuthors)
                .HasForeignKey(sc => sc.BookId);
            //.OnDelete(DeleteBehavior.Restrict)

            modelbuilder.Entity<BookAuthor>()
                .HasOne(sc => sc.Author)
                .WithMany(c => c.BookAuthors)
                .HasForeignKey(sc => sc.AuthorId);
            //.OnDelete(DeleteBehavior.Restrict)
        }
    }
}
