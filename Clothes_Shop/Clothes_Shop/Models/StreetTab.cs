using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Shop.Models
{
    public class StreetTab
    {
        [Key]
        public int StreetID { get; set; }
        public String StreetName { get; set; }
    }
}
