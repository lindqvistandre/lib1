using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lib2.Models
{
    public class Inventory
    {
        [Key]
        public int InventoryId { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public List<Rental> Rentals { get; set; }
       
        public bool Available
        {
            get
            {
                // ifall den skulle vara null är den ny. Då är den tillgänglig!
                if (Rentals == null)
                    return true;
                // ifall den aldrig hyrts ut är den tillgänglig!
                else if (Rentals.Count == 0)
                    return true;
                // har alla böcker lämnats tillbaka är den tillgänglig
                else if (Rentals.All(r => r.Returned))
                    return true;
                // annars är den inte tillgänglig
                else
                {
                    return false;
                }
            }
        }
    }
}
