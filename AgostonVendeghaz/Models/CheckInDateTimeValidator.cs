using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgostonVendeghaz.Models
{
    public class CheckInDateTimeValidator : ValidationAttribute
    {      
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var reservation = (ReservedRooms)validationContext.ObjectInstance;
            DateTime checkin = reservation.CheckIn;

            string nowString = DateTime.Now.ToString("yyyy/MM/dd");
            DateTime now = DateTime.Parse(nowString);

            return (checkin >= now) ?
                ValidationResult.Success :
                new ValidationResult("A foglalás erre a napra nem lehetséges! Kérem adjon meg egy későbbi időpontot!");
            
        }
    }
}