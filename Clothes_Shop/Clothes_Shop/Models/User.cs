using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Clothes_Shop.Models
{
    public partial class User
    {
        public User()
        {
            Basket = new HashSet<Basket>();
            ClientAddress = new HashSet<ClientAddress>();
            Opinion = new HashSet<Opinion>();
            Orders = new HashSet<Orders>();
        }

        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int? CityId { get; set; }
        public int? StreetId { get; set; }
        public int? HomeNumber { get; set; }
        public int? StreetNumber { get; set; }
        public bool AccessLevel { get; set; }

        public virtual ICollection<Basket> Basket { get; set; }
        public virtual ICollection<ClientAddress> ClientAddress { get; set; }
        public virtual ICollection<Opinion> Opinion { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
