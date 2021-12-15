using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Clothes_Shop.Models
{
    public partial class ColorTab
    {
        public ColorTab()
        {
            Product = new HashSet<Product>();
        }

        public int ColorId { get; set; }
        public string ColorName { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
