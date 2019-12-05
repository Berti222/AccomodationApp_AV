using AgostonVendeghaz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgostonVendeghaz.Controllers
{
    [Authorize(Roles = RoleName.Admin)]
    public class UnitPricesController : Controller
    {
        ApplicationDbContext _context;

        public UnitPricesController()
        {
            this._context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            this._context.Dispose();
        }

        // GET: UnitPrices
        public ActionResult Index()
        {
            List<UnitPrices> unitPrices = _context.UnitPrice.ToList();

            return View(unitPrices);
        }

        public ActionResult New()
        {
            UnitPrices unitPrice = new UnitPrices();
            return View(unitPrice);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(UnitPrices unitPrice)
        {
            if (unitPrice.Id == 0)
            {
                _context.UnitPrice.Add(unitPrice);
            }
            else
            {
                var unitPriceInDb = _context.UnitPrice.Single(u => u.Id == unitPrice.Id);

                unitPriceInDb.RoomPrice = unitPrice.RoomPrice;
                unitPriceInDb.DiscountFromDay = unitPrice.DiscountFromDay;
                unitPriceInDb.Discount = unitPrice.Discount;
                unitPriceInDb.ExtraBedPrice = unitPrice.ExtraBedPrice;
                unitPriceInDb.TouristTaxPrice = unitPrice.TouristTaxPrice;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "UnitPrices");
        }

        public ActionResult Edit(int id)
        {
            var unitPrice = _context.UnitPrice.SingleOrDefault(u => u.Id == id);

            if (unitPrice == null)
                return HttpNotFound();

            return View("New", unitPrice);
        }

        public ActionResult Delete(int id)
        {
            var unitPrice = _context.UnitPrice.SingleOrDefault(u => u.Id == id);

            var roomWithThisUnitPrice = _context.Rooms.SingleOrDefault(u => u.UnitPriceID == id);

            if (unitPrice == null)
                return HttpNotFound();

            if (roomWithThisUnitPrice == null)
            {
                _context.UnitPrice.Remove(unitPrice);
                _context.SaveChanges();
                return RedirectToAction("Index", "UnitPrices");
            }

            return RedirectToAction("Index", "UnitPrices");
        }

        public ActionResult CantDelete()
        {
            return View();
        }
    }
}