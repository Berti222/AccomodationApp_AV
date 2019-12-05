using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AgostonVendeghaz.Models
{
    public class Room
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        public string Description { get; set; }

        public int GuestFittingInTheRoom { get; set; }

        public int Available { get; set; }

        public int? UnitPriceID { get; set; }
        public UnitPrices UnitPrice { get; set; }
    }
}