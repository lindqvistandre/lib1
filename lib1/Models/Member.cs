﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lib1.Models
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }
        public string Email { get; set; }
        [Required]
        public string Phonenumber { get; set; }  // felsök korrigera till string om ej funkar.
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int LibraryCard { get; set; }
        public List<Rental> Rentals { get; set; }
    }
}
//       var rental = new Rental()


// fanns i members controll 
// {
//    MemberId = memberId,
//                InventoryId = availableInv.InventoryId,
//                RentalDate = DateTime.Now,
//               // ReturnDate = DateTime.Now.AddDays(30)

//            };