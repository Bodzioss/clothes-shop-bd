using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Clothes_Shop.Models
{
    public partial class Product
    {
        public Product()
        {
            BasketDetails = new HashSet<BasketDetails>();
            Opinion = new HashSet<Opinion>();
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Season { get; set; }
       
        public decimal Price { get; set; }
        public int GenderId { get; set; }
        public int ColorId { get; set; }
        public int SizeId { get; set; }
        public int MaterialId { get; set; }
        public string Pattern { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }

        public virtual BrandTab Brand { get; set; }
        public virtual CategoryTab Category { get; set; }
        public virtual ColorTab Color { get; set; }
        public virtual GenderTab Gender { get; set; }
        public virtual MaterialTab Material { get; set; }
        public virtual SizeTab Size { get; set; }
        public virtual ICollection<BasketDetails> BasketDetails { get; set; }
        public virtual ICollection<Opinion> Opinion { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
