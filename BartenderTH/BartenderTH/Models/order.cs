using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BartenderTH.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class order
    {
        public int Id { get; set; }
        public int drinkId { get; set; }

        public drinks drinks { get; set; }
    }
}