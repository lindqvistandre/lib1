using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lib1.Models
{
    public class Book
    {   
        [Key]
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Isbn { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public int Rating { get; set; }
        [Required]
        public int AuthorId { get; set; }
        public List<BookAuthor> BookAuthors { get; set; }

        public Inventory Inventory { get; set; }
    }
}
