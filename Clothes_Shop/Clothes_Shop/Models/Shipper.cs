using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Shop.Models
{
    public class Shipper
    {
        [Key]
        public int ShipperID { get; set; }
        public String CompanyName { get; set; }
        public String PhoneNumber { get; set; }
    }
}
