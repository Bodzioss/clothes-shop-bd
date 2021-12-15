using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Clothes_Shop.Models
{
    public partial class MaterialTab
    {
        public MaterialTab()
        {
            Product = new HashSet<Product>();
        }

        public int MaterialId { get; set; }
        public string MaterialName { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
