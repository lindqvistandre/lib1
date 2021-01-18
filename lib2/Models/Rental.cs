using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lib2.Models
{
    public class Rental
    {
        [Key]
        public int RentalId { get; set; }
        public int InventoryId { get; set; }
        public int MemberId { get; set; }
       
        public DateTime RentalDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime RentDue { get; set; }


        public Inventory Inventory { get; set; }
        public Member Member { get; set; }
        public Book Book { get; set; }          

       
        public bool Returned
        {
            get
            {
                // är return inte null så betyder det att boken inte är återlämnad
                return ReturnDate == null ? false : true;  // return ReturnDate != null;   // 
            }
        }
    }
}
