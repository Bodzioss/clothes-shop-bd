using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Shop.Models
{
    public class MaterialTab
    {
        [Key]
        public int MaterialID { get; set; }
        public String MaterialName { get; set; }

    }
}
