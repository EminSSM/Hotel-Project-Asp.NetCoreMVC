using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffservice;

        public StaffController(IStaffService staffservice)
        {
            _staffservice = staffservice;
        }

        [HttpGet]
        public IActionResult StaffList()
        {
            var list = _staffservice.TGetList();
            return Ok(list);
        }
        [HttpPost]
        public IActionResult AddStaff(Staff staff)
        {
            _staffservice.TInsert(staff);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStaff(int id)
        {
            var value = _staffservice.TGetById(id);
            _staffservice.TDelete(value);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateStaff(Staff staff)
        {
            _staffservice.TUpdate(staff);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetStaff(int id)
        {
            var value = _staffservice.TGetById(id);
            return Ok(value);
        }
        [HttpGet("GetList4Staff")]
        public IActionResult GetList4Staff()
        {
            var staff = _staffservice.TLast4Staff();
            return Ok(staff);   
        }
    }
}
