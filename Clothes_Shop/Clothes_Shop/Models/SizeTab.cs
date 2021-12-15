using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Shop.Models
{
    public class SizeTab
    {
        [Key]
        public int SizeiD { get; set; }
        public String SizeName { get; set; }
    }
}
