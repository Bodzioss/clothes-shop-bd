using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Shop.Models
{
    public class ColorTab
    {
        [Key]
        public int ColorID { get; set; }
        public String ColorName { get; set; }
    }
}
