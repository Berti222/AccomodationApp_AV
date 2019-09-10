using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgostonVendeghaz.Models
{
    public class ReserveRoom
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public byte RoomId { get; set; }

        public DateTime ReservedAt { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public int NumberOfPeople { get; set; }
        //public int PeopleUnder18 { get; set; }

        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
    }
}