using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageCategoryController : ControllerBase
    {
        private readonly IMessageCategoryService _messageCategoryservice;

        public MessageCategoryController(IMessageCategoryService messageCategoryservice)
        {
            _messageCategoryservice = messageCategoryservice;
        }

        [HttpGet]
        public IActionResult MessageCategoryList()
        {
            var list = _messageCategoryservice.TGetList();
            return Ok(list);
        }
        [HttpPost]
        public IActionResult AddMessageCategory(MessageCategory MessageCategory)
        {
            _messageCategoryservice.TInsert(MessageCategory);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMessageCategory(int id)
        {
            var value = _messageCategoryservice.TGetById(id);
            _messageCategoryservice.TDelete(value);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateMessageCategory(MessageCategory MessageCategory)
        {
            _messageCategoryservice.TUpdate(MessageCategory);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetMessageCategory(int id)
        {
            var value = _messageCategoryservice.TGetById(id);
            return Ok(value);
        }
    }
}
