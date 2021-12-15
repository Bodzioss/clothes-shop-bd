using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Shop.Models
{
    public class Orders
    {
        [Key]
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public String PaymentType { get; set; }
        public String PaymentStatus { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime ShipDate { get; set; }
        public int ShipperID { get; set; }
        public int Discount { get; set; }
    }
}
