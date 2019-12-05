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
                RoomId = id                        
                             
            };

            return View(reserving);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult ReserveRoom(ReservedRooms reserved)
        {
            //set room
            reserved.Room = _context.Rooms.Where(r => r.Id == reserved.RoomId).SingleOrDefault();
            // set UnitPrice
            reserved.Room.UnitPrice = _context.UnitPrice.Where(u => u.Id == reserved.Room.UnitPriceID).SingleOrDefault();

            // Set DateTime - ReservedAt
            reserved.ReservedAt = DateTime.Now;
            // Set UserId
            reserved.UserId = User.Identity.GetUserId();

            SaveInvoice(reserved);

            var userInvoices = _context
                            .Invoices
                            .Where(x => x.UserId == reserved.UserId)
                            .ToList();

            var invoiceInDb = userInvoices
                            .SingleOrDefault
                            (x =>x.ReservedAt.ToString() == reserved.ReservedAt.ToString());
                            
            reserved.InvoiceId = invoiceInDb.Id;

            _context.ReserveRooms.Add(reserved);
            _context.SaveChanges();

            //List<ReservedRooms> reservedRoomsInDb = _context
            //                                    .ReserveRooms
            //                                    .Where(x => x.UserId == reserved.UserId)
            //                                    .ToList();

            //ReservedRooms reservedRoom = reservedRoomsInDb
            //                            .SingleOrDefault(x => x.ReservedAt == reserved.ReservedAt);

            return RedirectToAction("ShowInvoice", "RoomReservation", new { id = reserved.Id });            
        }

        private void SaveInvoice(ReservedRooms reserved)
        {
            var calculateMethods = new CalculateMethods(reserved);
            var invoice = calculateMethods.CalculateInvoice();
            _context.Invoices.Add(invoice);
            _context.SaveChanges();
        }

        // /RoomReservation/ShowInvoice/1
        [HttpGet]
        public ActionResult ShowInvoice(int id)
        {
            if (!User.Identity.IsAuthenticated)
                return HttpNotFound();

            var reservedRoomInDb = _context.ReserveRooms.SingleOrDefault(x => x.Id == id);
            reservedRoomInDb.Invoice = _context.Invoices.SingleOrDefault(x => x.Id == reservedRoomInDb.InvoiceId);

            string userId = User.Identity.GetUserId();
            if (reservedRoomInDb.UserId != userId)
                return HttpNotFound();

            return View(reservedRoomInDb);
        }
    }
}