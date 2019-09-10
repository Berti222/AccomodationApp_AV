using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgostonVendeghaz.Models
{
    public class UnitPrices
    {
        public byte Id { get; set; }

        public int RoomPrice { get; set; }
        public int DiscountFromDay { get; set; }
        public double Discount { get; set; }
        public int ExtraBedPrice { get; set; }
        public int TouristTaxPrice { get; set; }
    }
}