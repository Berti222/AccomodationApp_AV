using AgostonVendeghaz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgostonVendeghaz.Controllers
{
    public class RoomReservationController : Controller
    {
        ApplicationDbContext _context;
        public RoomReservationController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
           _context.Dispose();
        }

        // GET: RoomReservation
        public ActionResult Index()
        {
            var rooms = _context.Rooms.ToList();
            return View(rooms);
        }

        public ActionResult Reserving(int id)
        {
            var reserving = new ReserveRoom()
            {
                RoomId = id,
                CheckIn = DateTime.Now,
                CheckOut = DateTime.Now                            
            };

            return View(reserving);
        }
    }
}