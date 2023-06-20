using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.GuestDto;
using HotelProject.WebUI.Dtos.ServiceDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class BookingAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingAdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("http://localhost:5100/api/Booking");
            if (responsemessage.IsSuccessStatusCode)
            {
                var jsonData = await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> ApprovedReservation2(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync($"http://localhost:5100/api/Booking/BookingApproved{id}");
            if (responsemessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return View();

        }
        public async Task<IActionResult> CancelReservation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync($"http://localhost:5100/api/Booking/BookingCancel?id={id}");
            if (responsemessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return View();

        }
        public async Task<IActionResult> WaitReservation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync($"http://localhost:5100/api/Booking/BookingWait?id={id}");
            if (responsemessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return View();

        }
        [HttpGet]
        public async Task<IActionResult> UpdateReservation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync($"http://localhost:5100/api/Booking/{id}");
            if (responsemessage.IsSuccessStatusCode)
            {
                var jsonData = await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBookingDto>(jsonData);
                return View(values);
            }
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> UpdateReservation(UpdateBookingDto updateBookingDto)
        {
         
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(updateBookingDto);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responsemessage = await client.PutAsync("http://localhost:5100/api/Booking/UpdateBooking", content);
                if (responsemessage.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
                return View();
            }
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.DeleteAsync($"http://localhost:5100/api/Booking?id={id}");
            if (responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> ApprovedReservation(ApprovedReservationDto approvedReservationDto)
        {
            approvedReservationDto.Status = "Onaylandı";
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(approvedReservationDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responsemessage = await client.PutAsync("http://localhost:5100/api/Booking/", content);
            if (responsemessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return View();

        }
    }
}
