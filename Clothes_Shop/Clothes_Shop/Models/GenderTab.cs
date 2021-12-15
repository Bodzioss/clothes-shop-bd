using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Shop.Models
{
    public class GenderTab
    {
        [Key]
        public int GenderID { get; set; }
        public String GenderName { get; set; }
    }
}
