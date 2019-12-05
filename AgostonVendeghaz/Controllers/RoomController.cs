using AgostonVendeghaz.Dtos;
using AgostonVendeghaz.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgostonVendeghaz.Controllers
{
    public class RoomController : Controller
    {
        public ApplicationDbContext _context;
        private List<UnitPrices> unitPrices;

        public RoomController()
        {
            _context = new ApplicationDbContext();
            unitPrices = _context.UnitPrice.ToList();
        }

        protected override void Dispose(bool disposing)
        {
            this._context.Dispose();
        }


        // GET: Room
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Index()
        {
            var rooms = _context.Rooms.ToList();
            return View(rooms);
        }

        [Authorize(Roles = RoleName.Admin)]
        public ActionResult New()
        {
            var room = new Room();

            var newRoomDto = new NewRoomDTO(room,unitPrices);

            return View(newRoomDto);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Save(Room room)
        {
            if (room.Id == 0)
            {               
                _context.Rooms.Add(room);
            }
            else
            {
                var roomInDb = _context.Rooms.Single(r => r.Id == room.Id);

                roomInDb.Available = room.Available;                
                roomInDb.Description = room.Description;                
                roomInDb.GuestFittingInTheRoom = room.GuestFittingInTheRoom;                
                roomInDb.Type = room.Type;
                roomInDb.UnitPriceID = room.UnitPriceID;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Room");
        }

        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Edit(int id)
        {
            var room = _context.Rooms.SingleOrDefault(r => r.Id == id);

            var newRoomDto = new NewRoomDTO(room, unitPrices);

            if (room == null)
                return HttpNotFound();

            return View("New", newRoomDto);
        }

        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Delete(int id)
        {
            var room = _context.Rooms.SingleOrDefault(r => r.Id == id);

            if (room == null)
                return HttpNotFound();

            _context.Rooms.Remove(room);
            _context.SaveChanges();

            return RedirectToAction("Index", "Room");
        }
    }
}