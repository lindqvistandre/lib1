﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lib1.Models
{
    public class Rental
    {
        [Key]
        public int RentalId { get; set; }
        public int InventoryId { get; set; }
        public int MemberId { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public Inventory Inventory { get; set; }
        public Member Member { get; set; }

        // computed property. Räknas ut from andra properties
        // saknas setter så kommer EF ignorera vid add migrations
        public bool Returned
        {
            get
            {
                // är return inte null så betyder det att filmen inte är återlämnad
                return ReturnDate != null;
            }
        }
    }
}