using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMessageController : ControllerBase
    {
        private readonly ISendMessageService _sendMessageservice;

        public SendMessageController(ISendMessageService sendMessageservice)
        {
            _sendMessageservice = sendMessageservice;
        }

        [HttpGet]
        public IActionResult SendMessageList()
        {
            var list = _sendMessageservice.TGetList();
            return Ok(list);
        }
        [HttpPost]
        public IActionResult AddSendMessage(SendMessage SendMessage)
        {
            _sendMessageservice.TInsert(SendMessage);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSendMessage(int id)
        {
            var value = _sendMessageservice.TGetById(id);
            _sendMessageservice.TDelete(value);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateSendMessage(SendMessage SendMessage)
        {
            _sendMessageservice.TUpdate(SendMessage);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetSendMessage(int id)
        {
            var value = _sendMessageservice.TGetById(id);
            return Ok(value);
        }
        [HttpGet("GetSendMessageCount")]
        public IActionResult GetSendMessageCount()
        {
            return Ok(_sendMessageservice.TGetSendMessageCount());
        }
    }
}
