using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgostonVendeghaz.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        public int NumberOfNights { get; set; }

        public int RoomPriceWithoutDiscount { get; set; }

        public int RoomPriceWithDiscount { get; set; }

        public int DiscountPercent { get; set; }

        //public int TouristTax { get; set; }

        public int ExtraBed { get; set; }
        public int ExtraBedPrice { get; set; }
    }
}