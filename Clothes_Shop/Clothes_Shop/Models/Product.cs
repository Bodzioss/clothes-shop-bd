using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Shop.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public String ProductName { get; set; }
        public String Season { get; set; }
        public float Price { get; set; }
        public int GenderID { get; set; }
        public int ColorID { get; set; }
        public int SizeID { get; set; }
        public int MaterialID { get; set; }
        public String Pattern { get; set; }
        public int BrandID { get; set; }
        public int CategoryID { get; set; }
        public int Amount { get; set; }
        public String Description { get; set; }
        public String Picture { get; set; }

    }
}
