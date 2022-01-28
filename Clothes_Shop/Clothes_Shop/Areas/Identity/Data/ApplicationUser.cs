using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Clothes_Shop.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public String FirstName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public String LastName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public String CityName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public String StreetName { get; set; }

        [PersonalData]
        [Column(TypeName = "int")]
        public int HomeNumber { get; set; }

        [PersonalData]
        [Column(TypeName = "int")]
        public int StreetNumber { get; set; }

    }
}
