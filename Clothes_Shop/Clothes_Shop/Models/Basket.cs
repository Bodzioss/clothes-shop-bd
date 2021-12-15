using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Shop.Models
{
    public class Basket
    {
        [Key]
        public int BasketID { get; set; }
        [Required]
        public int UserID { get; set; }
    }
}
