using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgostonVendeghaz.Models
{
    public class NewRoomDTO
    {
        public Room Room { get; set; }
        public List<UnitPrices> UnitPrices { get; set; }

        public NewRoomDTO(Room room, List<UnitPrices> unitPrices)
        {
            this.Room = room;
            this.UnitPrices = unitPrices;
        }
    }
}