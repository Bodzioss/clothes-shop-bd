using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Shop.Models
{
    public class BrandTab
    {
        [Key]
        public int BrandID { get; set; }
        public String BrandName { get; set; }
    }
}
