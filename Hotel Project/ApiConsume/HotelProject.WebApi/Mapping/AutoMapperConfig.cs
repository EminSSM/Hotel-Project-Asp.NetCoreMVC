using AutoMapper;
using HotelProject.DtoLayer.DTOS.RoomDto;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.WebApi.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<RoomAddDto, Room>();
            CreateMap<Room,RoomAddDto>();

            CreateMap<RoomUpdateDto, Room>().ReverseMap();
        }
    }
}
