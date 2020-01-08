using AgostonVendeghaz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace AgostonVendeghaz.Controllers
{
    [Authorize(Roles = RoleName.Admin)]
    public class ReservationsController : Controller
    {
        public ApplicationDbContext _context;
        private List<UnitPrices> unitPrices;

        public ReservationsController()
        {
            _context = new ApplicationDbContext();
            unitPrices = _context.UnitPrice.ToList();

        }

        protected override void Dispose(bool disposing)
        {
            this._context.Dispose();
        }

        // GET: Reservations
        public ActionResult Index()
        {
            var reservedRooms = _context.ReserveRooms.Include(r => r.Invoice).OrderByDescending(x => x.CheckIn).ToList();

            return View(reservedRooms);
        }


        public ActionResult Delete(int id)
        {
            var reservedRoom = _context.ReserveRooms.Where(r => r.Id == id).SingleOrDefault();
            int? invoiceID = reservedRoom.InvoiceId;

            if (invoiceID != null)
            {
                Invoice invoice = _context.Invoices.Where(i => i.Id == invoiceID).SingleOrDefault();
                _context.Invoices.Remove(invoice);
            }
            _context.ReserveRooms.Remove(reservedRoom);
            _context.SaveChanges();

            return RedirectToAction("Index", "Reservations");
        }
    }
}