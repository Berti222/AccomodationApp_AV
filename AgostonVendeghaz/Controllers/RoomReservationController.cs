using AgostonVendeghaz.Models;
using Microsoft.AspNet.Identity;
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

        [Authorize]
        public ActionResult Reserving(int id)
        {
            var reserving = new ReservedRooms()
            {
                RoomId = id,
                CheckIn = DateTime.Now,
                CheckOut = DateTime.Now                            
            };

            return View(reserving);
        }

        [Authorize]
        public ActionResult ReserveRoom(ReservedRooms reserved)
        {
            // Set DateTime - ReservedAt
            reserved.ReservedAt = DateTime.Now;
            // Set UserId
            reserved.UserId = User.Identity.GetUserId();

            var invoice = CalculateMethods.CalculateInvoice(reserved);
            _context.Invoices.Add(invoice);
            _context.SaveChanges();

            var invoiceInDb = _context
                            .Invoices
                            .Where(x => x.UserId == reserved.UserId 
                            && x.ReservedAt == reserved.ReservedAt)
                            .SingleOrDefault();
            reserved.InvoiceId = invoiceInDb.Id;

            _context.ReserveRooms.Add(reserved);
            _context.SaveChanges();
            return View();
        }
    }
}