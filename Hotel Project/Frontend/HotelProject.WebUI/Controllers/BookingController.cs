using HotelProject.WebUI.Dtos.BookingDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult AddBooking()
        {
            return PartialView();   
        }
        [HttpPost]
        public async Task<IActionResult> AddBooking(CreateBookingDto createBooking)
        {
            createBooking.Status = "Onay bekliyor";
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(createBooking);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            await client.PostAsync("http://localhost:5100/api/Booking", content);

            return RedirectToAction("Index", "Default");
        }
    }
}
