using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.DTOS.RoomDto;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Room2Controller : ControllerBase
    {
        private readonly IRoomService _roomservice;
        private readonly IMapper _mapper;

        public Room2Controller(IRoomService roomservice, IMapper mapper)
        {
            _roomservice = roomservice;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var values = _roomservice.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddRoom(RoomAddDto roomAddDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = _mapper.Map<Room>(roomAddDto);
             _roomservice.TInsert(values);
         
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateRoom(RoomUpdateDto updatedto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = _mapper.Map<Room>(updatedto);
            _roomservice.TUpdate(values);

            return Ok("Başarıyla güncellendi");
        }
    }
}
