using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Shop.Models
{
    public class CategoryTab
    {
        [Key]
        public int CategoryID { get; set; }
        public String CategoryName { get; set; }
        public String Description { get; set; }
        public String Picture { get; set; }
    }
}
