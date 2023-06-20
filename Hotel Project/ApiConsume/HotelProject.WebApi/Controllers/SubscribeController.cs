using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscribeService _subscribeservice;

        public SubscribeController(ISubscribeService subscribeservice)
        {
            _subscribeservice = subscribeservice;
        }

        [HttpGet]
        public IActionResult SubscribeList()
        {
            var list = _subscribeservice.TGetList();
            return Ok(list);
        }
        [HttpPost]
        public IActionResult AddSubscribe(Subscribe Subscribe)
        {
            _subscribeservice.TInsert(Subscribe);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteSubscribe(int id)
        {
            var value = _subscribeservice.TGetById(id);
            _subscribeservice.TDelete(value);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateSubscribe(Subscribe Subscribe)
        {
            _subscribeservice.TUpdate(Subscribe);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetSubscribe(int id)
        {
            var value = _subscribeservice.TGetById(id);
            return Ok(value);
        }
    }
}
