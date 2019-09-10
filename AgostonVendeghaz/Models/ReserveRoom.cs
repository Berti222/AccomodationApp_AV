using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgostonVendeghaz.Models
{
    public class ReserveRoom
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public int RoomId { get; set; }

        public DateTime ReservedAt { get; set; }
        [Display(Name ="Érkezés napja: ")]
        public DateTime CheckIn { get; set; }
        [Display(Name ="Távozás napja: ")]
        public DateTime CheckOut { get; set; }

        [Display(Name ="Érkező vendégek száma: ")]
        public int NumberOfPeople { get; set; }
        //public int PeopleUnder18 { get; set; }

        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
    }
}