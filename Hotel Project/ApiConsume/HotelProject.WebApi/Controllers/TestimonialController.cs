using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialservice;

        public TestimonialController(ITestimonialService testimonialservice)
        {
            _testimonialservice = testimonialservice;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var list = _testimonialservice.TGetList();
            return Ok(list);
        }
        [HttpPost]
        public IActionResult AddTestimonial(Testimonial Testimonial)
        {
            _testimonialservice.TInsert(Testimonial);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialservice.TGetById(id);
            _testimonialservice.TDelete(value);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(Testimonial Testimonial)
        {
            _testimonialservice.TUpdate(Testimonial);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _testimonialservice.TGetById(id);
            return Ok(value);
        }
    }
}
