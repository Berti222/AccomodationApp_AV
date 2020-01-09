using AgostonVendeghaz.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgostonVendeghaz.Controllers
{
    public class ChangeUserDataController : Controller
    {
        ApplicationDbContext _context;
        public ChangeUserDataController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            this._context.Dispose();
        }

        // GET: ChangeUserData
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();

            ApplicationUser user = _context.Users.Where(u => u.Id == userId).SingleOrDefault();

            if (user == null)
                return HttpNotFound();

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Post(ApplicationUser user)
        {
            ApplicationUser userInDb = _context.Users.SingleOrDefault(u => u.Id == user.Id);

            if (userInDb == null)
                return HttpNotFound();

            userInDb.Name = user.Name;
            userInDb.ZipCode = user.ZipCode;
            userInDb.City = user.City;
            userInDb.Street = user.Street;
            userInDb.HouseNumber = user.HouseNumber;
            userInDb.Phone = user.Phone;

            _context.SaveChanges();

            return RedirectToAction("Index", "Manage");
        }

    }
}