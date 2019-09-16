using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgostonVendeghaz.Models
{
    public class CalculateMethods
    {

        public static Invoice CalculateInvoice(ReservedRooms reserve)
        {
            ApplicationDbContext _context = new ApplicationDbContext();
            UnitPrices unitPrices = _context.UnitPrice.Where(x => x.Id == 1).SingleOrDefault();

            Invoice invoice = new Invoice();

            //nights            
            invoice.NumberOfNights = CalculateMethods.Nights(reserve);
            //extra bed
            invoice.ExtraBed = CalculateMethods.ExtraBed(reserve);
            //extra bed price            
            invoice.ExtraBedPrice = CalculateMethods.ExtraBedPrice(reserve, unitPrices);
            // RoomPrice Without Discount
            invoice.RoomPriceWithoutDiscount = CalculateMethods.RoomPriceWithoutDiscount(reserve, unitPrices);
            // RoomPrice With Discount
            invoice.RoomPriceWithDiscount = CalculateMethods.RoomPriceWithDiscount(reserve, unitPrices);
            // User Id
            invoice.UserId = reserve.UserId;
            // Reserved At
            invoice.ReservedAt = reserve.ReservedAt;

            invoice.DiscountPercent = (int)(unitPrices.Discount * 100);

            return invoice;
        }

        private static int Nights(ReservedRooms reserve)
        {
            TimeSpan nightsSpan = reserve.CheckOut - reserve.CheckIn;
            int nights = nightsSpan.Days;

            return nights;
        }

        private static int ExtraBed(ReservedRooms reserve)
        {
            int extraBed = reserve.NumberOfPeople - 2 > 0 ? reserve.NumberOfPeople - 2 : 0;
            return extraBed;
        }

        private static int ExtraBedPrice(ReservedRooms reserve, UnitPrices unitPrice)
        {
            int extraBed = CalculateMethods.ExtraBed(reserve);
           
            int result = extraBed * unitPrice.ExtraBedPrice;
            return result;
        }

        private static int DiscountPrice(ReservedRooms reserve, UnitPrices unitPrice)
        {
            int nights = CalculateMethods.Nights(reserve);
            int extraBedPriceForOneNight = CalculateMethods.ExtraBedPrice(reserve, unitPrice);
            int extraBedPrice = nights * extraBedPriceForOneNight;

            int priceWithoutExtraBed = nights * unitPrice.RoomPrice;
            int price = priceWithoutExtraBed + extraBedPrice;

            double priceWithDiscountDouble = price * unitPrice.Discount;
            int priceWithDiscount = (int)Math.Round(priceWithDiscountDouble);           

            int result = (nights >= unitPrice.DiscountFromDay) ?
                                priceWithDiscount : price;

            return result;
        }

        private static int RoomPriceWithoutDiscount(ReservedRooms reserve, UnitPrices unitPrice)
        {
            int nights = CalculateMethods.Nights(reserve);
            double priceDouble = nights * unitPrice.RoomPrice;          
            int price = (int)Math.Round(priceDouble);

            int extraBedPrices = CalculateMethods.ExtraBedPrice(reserve, unitPrice);

            int result = price + extraBedPrices;

            return result;
        }

        private static int RoomPriceWithDiscount(ReservedRooms reserve, UnitPrices unitPrice)
        {
            int roomPriceWithoutDiscount = CalculateMethods.RoomPriceWithoutDiscount(reserve, unitPrice);
            int discountPrice = CalculateMethods.DiscountPrice(reserve, unitPrice);

            return roomPriceWithoutDiscount - discountPrice;
        }
    }
}