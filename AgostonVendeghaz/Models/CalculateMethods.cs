using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgostonVendeghaz.Models
{
    public class CalculateMethods
    {
        private ApplicationDbContext _context;
        private ReservedRooms reserve;
        private UnitPrices unitPrice;
        private Invoice invoice;


        public CalculateMethods(ReservedRooms reserve)
        {
            _context = new ApplicationDbContext();
            invoice = new Invoice();
            this.reserve = reserve;
            this.unitPrice = reserve.Room.UnitPrice;
        }

        public Invoice CalculateInvoice()
        {

            //nights            
            invoice.NumberOfNights = Nights();
            //extra bed
            invoice.ExtraBed = ExtraBed();
            //extra bed price            
            invoice.ExtraBedPrice = ExtraBedPrice();
            // RoomPrice Without Discount
            invoice.RoomPriceWithoutDiscount = RoomPriceWithoutDiscount();
            // RoomPrice With Discount
            invoice.RoomPriceWithDiscount = RoomPriceWithDiscount();
            // User Id
            invoice.UserId = reserve.UserId;
            // Reserved At
            invoice.ReservedAt = reserve.ReservedAt;

            invoice.DiscountPercent = DiscountPercent();

            return invoice;
        }

        private int Nights()
        {
            TimeSpan nightsSpan = reserve.CheckOut - reserve.CheckIn;
            int nights = nightsSpan.Days;

            return nights;
        }

        private int ExtraBed()
        {
            int extraBed = reserve.NumberOfPeople > 2 ? reserve.NumberOfPeople - 2 : 0;
            return extraBed;
        }

        private int ExtraBedPrice()
        {
            int extraBed = ExtraBed();
           
            int result = extraBed * unitPrice.ExtraBedPrice;
            return result;
        }

        private int RoomPriceWithoutDiscount()
        {
            int nights = Nights();
            int price = nights * unitPrice.RoomPrice;

            int extraBedPricesFroOneNight = ExtraBedPrice();
            int extraBedPrices = extraBedPricesFroOneNight * nights;

            int result = price + extraBedPrices;

            return result;
        }

        private int DiscountPrice()
        {
            int nights = Nights();
            int price = RoomPriceWithoutDiscount();

            double priceWithDiscountDouble = price * unitPrice.Discount;
            int priceWithDiscount = (int)Math.Round(priceWithDiscountDouble);           

            int result = (nights >= unitPrice.DiscountFromDay) ?
                                priceWithDiscount : 0;

            return result;
        }

        private int RoomPriceWithDiscount()
        {
            int roomPriceWithoutDiscount = RoomPriceWithoutDiscount();
            int discountPrice = DiscountPrice();

            return roomPriceWithoutDiscount - discountPrice;
        }

        private int DiscountPercent()
        {
            bool haveDiscount = Nights() >= unitPrice.DiscountFromDay;
            int discount = (int)(unitPrice.Discount * 100);
            return haveDiscount ? discount : 0;
        }
    }
}