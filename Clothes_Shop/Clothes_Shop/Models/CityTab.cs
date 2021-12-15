using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Shop.Models
{
    public class CityTab
    {
        [Key]
        public int CityID { get; set; }
        public String CityName { get; set; }
    }
}
