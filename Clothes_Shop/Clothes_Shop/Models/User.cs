using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Shop.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public String Login { get; set; }
        public String Password { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String PhoneNumber { get; set; }
        public int CityID { get; set; }
        public int StreetID { get; set; }
        public int StreetNumber { get; set; }
        public int HomeNumber { get; set; }
        public bool AccessLevel { get; set; }
    }
}
