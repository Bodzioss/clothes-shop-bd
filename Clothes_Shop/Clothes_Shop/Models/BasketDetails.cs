using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Shop.Models
{
    public class BasketDetails
    {
        [Key]
        public int BasketDetailsID { get; set; }
        public int BasketID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
    }
}
