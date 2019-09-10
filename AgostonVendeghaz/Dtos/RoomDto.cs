using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgostonVendeghaz.Dtos
{
    public class RoomDto
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        public string Description { get; set; }

        public int GuestFittingInTheRoom { get; set; }

        public int Available { get; set; }
    }
}