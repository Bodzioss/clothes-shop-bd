using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Clothes_Shop.Models
{
    public partial class ClientAddress
    {
        public int ClientAddressId { get; set; }
        public int UserId { get; set; }
        public int CityId { get; set; }
        public int StreetId { get; set; }
        public string StreetNumber { get; set; }
        public string HomeNumber { get; set; }
        public bool IsMain { get; set; }
    }
}
