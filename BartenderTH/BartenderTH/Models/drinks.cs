using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BartenderTH.Models
{
    using System.ComponentModel.DataAnnotations;

    public class drinks
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }

        //public order order { get; set; }
    }
}