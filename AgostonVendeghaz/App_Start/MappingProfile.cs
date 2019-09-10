using AgostonVendeghaz.Dtos;
using AgostonVendeghaz.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgostonVendeghaz.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Room, RoomDto>();
            Mapper.CreateMap<RoomDto, Room>().ForMember(r => r.Id, opt => opt.Ignore());

            Mapper.CreateMap<Room, Room>().ForMember(r => r.Id, opt => opt.Ignore());
        }
    }
}