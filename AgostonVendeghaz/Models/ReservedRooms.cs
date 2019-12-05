using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgostonVendeghaz.Models
{
    public class ReservedRooms
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        //Address
        [Required]
        [Display(Name = "Név")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Irányítószám")]
        [RegularExpression(@"^[1-9]\d{3}[.]?$",
            ErrorMessage = "Helytelen formátum! Kérem próbálja újra.")]
        [StringLength(5)]
        public string ZipCode { get; set; }

        [Required]
        [Display(Name = "Város")]
        [StringLength(100)]
        [RegularExpression(@"^[a-zA-Z\u00C0-\u00FFűőŰŐ .\-]{2,}$",
            ErrorMessage ="Helytelen formátum! Kérem próbálja újra.")]
        public string City { get; set; }

        [Required]
        [Display(Name ="Utca")]
        [StringLength(255)]
        [RegularExpression(@"^[a-zA-Z\u00C0-\u00FFűőŰŐ \-.]{2,}$",
            ErrorMessage = "Helytelen formátum! Kérem próbálja újra.")]
        public string Street { get; set; }

        [Required]
        [Display(Name ="Házszám")]
        [StringLength(50)]
        [RegularExpression(@"^\d{1,4}[.\-/ ]?[0-9a-zA-Z\u00C0-\u00FFűőŰŐ \-.:/]*?$",
            ErrorMessage = "Helytelen formátum! Kérem próbálja újra.")]
        public string HouseNumber { get; set; }

        //Phone
        [Required]
        [Display(Name ="Telefonszám")]
        [RegularExpression(@"^\+?\d{2}[\-. ]?\d{1,2}[\-. ]?\d{3}[\-. ]?\d{3,4}$",
            ErrorMessage = "Helytelen formátum kérem próbálja újra!")]
        public string PhoneNumber { get; set; }

        //E-mail
        [Display(Name = "E-mail cím")]
        [EmailAddress]
        public string Email { get; set; }

        public int RoomId { get; set; }
        public Room Room { get; set; }

        public DateTime ReservedAt { get; set; }

        [Display(Name ="Érkezés napja")]
        [CheckInDateTimeValidator]
        public DateTime CheckIn { get; set; }

        [Display(Name ="Távozás napja")]
        public DateTime CheckOut { get; set; }

        [Display(Name ="Érkező vendégek száma")]

        public int NumberOfPeople { get; set; }
        
        //public int PeopleUnder18 { get; set; }

        public int? InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
    }
}