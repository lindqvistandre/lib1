using Lib2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lib2.Data
{
    public class Lib2DbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        //DateTime date_01 = new DateTime(2020, 07, 30, 6, 30, 0);
        //DateTime date_02 = new DateTime(2020, 08, 30, 6, 30, 0);
        //DateTime date_03 = new DateTime(2020, 09, 30, 6, 30, 0);
        //DateTime date_04 = new DateTime(2020, 10, 30, 6, 30, 0);
        //DateTime date_05 = new DateTime(2020, 11, 30, 6, 30, 0);
        //DateTime date_06 = new DateTime(2021, 1, 15, 6, 30, 0);

        //DateTime duedate_01 = new DateTime(2020, 8, 30, 3, 30, 0);
        //DateTime duedate_02 = new DateTime(2020, 9, 30, 3, 30, 0);
        //DateTime duedate_03 = new DateTime(2020, 10, 30, 3, 30, 0);
        //DateTime duedate_04 = new DateTime(2020, 11, 30, 3, 30, 0);
        //DateTime duedate_05 = new DateTime(2020, 12, 30, 3, 30, 0);
        //DateTime duedate_06 = new DateTime(2021, 2, 15, 4, 30, 0);

        public Lib2DbContext(DbContextOptions<Lib2DbContext> options) : base(options)
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


            modelbuilder.Entity<BookAuthor>()
                .HasOne(sc => sc.Author)
                .WithMany(c => c.BookAuthors)
                .HasForeignKey(sc => sc.AuthorId);


           // modelbuilder.Entity<Author>().HasData(
           //    new Author { AuthorId = 1, FirstName = "Magiska", LastName = "Fingrar" },
           //    new Author { AuthorId = 2, FirstName = "Blåa", LastName = "Svanen" },
           //    new Author { AuthorId = 3, FirstName = "Space", LastName = "Jam" },
           //    new Author { AuthorId = 4, FirstName = "Nils", LastName = "Petersson" }

           //);

           // modelbuilder.Entity<Book>().HasData(  
           //     new Book { BookId = 1, Isbn = 14324, Title = "Svärdet i Stenen", Year = 2012, Rating = 8 }, // , AuthorId = 1
           //     new Book { BookId = 2, Isbn = 15423, Title = "Tintins värld", Year = 2013, Rating = 7 }, // , AuthorId = 2 
           //     new Book { BookId = 3, Isbn = 78345, Title = "Titanic", Year = 1997, Rating = 5 }, //, AuthorId = 3 
           //     new Book { BookId = 4, Isbn = 17234, Title = "Braveheart", Year = 1998, Rating = 4 }, //,  AuthorId = 4 
           //     new Book { BookId = 5, Isbn = 71234, Title = "Robinhood", Year = 1843, Rating = 1 } // , AuthorId = 4 
           //      );

           // modelbuilder.Entity<BookAuthor>().HasData(
           //     new BookAuthor { BookId = 1, AuthorId = 1 },
           //     new BookAuthor { BookId = 2, AuthorId = 2 },
           //     new BookAuthor { BookId = 3, AuthorId = 3 },
           //     new BookAuthor { BookId = 4, AuthorId = 4 },
           //     new BookAuthor { BookId = 5, AuthorId = 4 }
           //     );

           // modelbuilder.Entity<Member>().HasData(
           //     new Member { MemberId = 1, FirstName = "Nalle", LastName = "Puh", Phonenumber = "070-100000" },
           //     new Member { MemberId = 2, FirstName = "Ture", LastName = "Sventon", Phonenumber = "070-200000" },
           //     new Member { MemberId = 3, FirstName = "Nils", LastName = "Pyssling", Phonenumber = "070-300000" }
           //     );

            //modelbuilder.Entity<Inventory>().HasData(
            //    new Inventory { InventoryId = 1, BookId = 1 },
            //    new Inventory { InventoryId = 2, BookId = 2 },
            //    new Inventory { InventoryId = 3, BookId = 3 },
            //    new Inventory { InventoryId = 4, BookId = 4 },
            //    new Inventory { InventoryId = 5, BookId = 5 }
            //     );

            //modelbuilder.Entity<Rental>().HasData(
            //    new Rental { RentalId = 1, MemberId = 1, InventoryId = 1, RentalDate = date_01, ReturnDate = date_02, RentDue = duedate_01 },
            //    new Rental { RentalId = 2, MemberId = 2, InventoryId = 5, RentalDate = date_03, RentDue = duedate_02 },
            //    new Rental { RentalId = 3, MemberId = 3, InventoryId = 4, RentalDate = date_05, RentDue = duedate_03 },
            //    new Rental { RentalId = 4, MemberId = 1, InventoryId = 6, RentalDate = date_06, RentDue = duedate_04 }
            //    );
        }
    }
}
