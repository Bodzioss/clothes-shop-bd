using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Shop.Models
{
    public class Opinion
    {
        [Key]
        public int OpinionID { get; set; }
        public int ProductID { get; set; }
        public int UserID { get; set; }
        public String Text { get; set; }
        public DateTime Date { get; set; }
        public int Rate { get; set; }
    }
}
