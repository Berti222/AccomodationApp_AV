using AgostonVendeghaz.Dtos;
using AgostonVendeghaz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;

namespace AgostonVendeghaz.App_Start.Api
{
    public class RoomsController : ApiController
    {
        private ApplicationDbContext _context;

        public RoomsController()
        {
            _context = new ApplicationDbContext();
        }

        
        // GET api/rooms
        public IEnumerable<RoomDto> GetRooms()
        {
            var roomsDto = _context.Rooms.ToList().Select(Mapper.Map<Room, RoomDto>);
            return roomsDto;
        }

        //POST api/rooms
        [HttpPost]
        public IHttpActionResult CreateRoom(RoomDto roomDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var room = Mapper.Map<RoomDto, Room>(roomDto);
            _context.Rooms.Add(room);
            _context.SaveChanges();

            roomDto.Id = room.Id;

            return Created(new Uri($"{Request.RequestUri}/{room.Id}"),roomDto);
        }

        //PUT api/rooms/1
        [HttpPut]
        public void PutRoom(int id, RoomDto roomDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var room = _context.Rooms.SingleOrDefault(r => r.Id == id);

            Mapper.Map(roomDto, room);
            _context.SaveChanges();
        }

        // DELETE api/rooms/1
        [HttpDelete]
        public void Delete(int id)
        {
            var room = _context.Rooms.SingleOrDefault(r => r.Id == id);

            if (room == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Rooms.Remove(room);
            _context.SaveChanges();
        }
    }
}
