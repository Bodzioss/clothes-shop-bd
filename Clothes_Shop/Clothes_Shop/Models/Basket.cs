using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Clothes_Shop.Models
{
    public partial class Basket
    {
        public Basket()
        {
            BasketDetails = new HashSet<BasketDetails>();
        }

        public int BasketId { get; set; }
        public string UserId { get; set; }

        public virtual AspNetUsers User { get; set; }
        public virtual ICollection<BasketDetails> BasketDetails { get; set; }
    }
}
