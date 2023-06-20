using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceservice;

        public ServiceController(IServiceService serviceservice)
        {
            _serviceservice = serviceservice;
        }

        [HttpGet]
        public IActionResult ServiceList()
        {
            var list = _serviceservice.TGetList();
            return Ok(list);
        }
        [HttpPost]
        public IActionResult AddService(Service Service)
        {
            _serviceservice.TInsert(Service);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteService(int id)
        {
            var value = _serviceservice.TGetById(id);
            _serviceservice.TDelete(value);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateService(Service Service)
        {
            _serviceservice.TUpdate(Service);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetService(int id)
        {
            var value = _serviceservice.TGetById(id);
            return Ok(value);
        }
    }
}
