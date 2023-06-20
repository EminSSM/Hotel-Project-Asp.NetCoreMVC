using HotelProject.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardWidgetPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardWidgetPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("http://localhost:5100/api/DashboardWidgets/StaffCount");
            var jsonData = await responsemessage.Content.ReadAsStringAsync();
            ViewBag.staffCount = jsonData;


            var client2 = _httpClientFactory.CreateClient();
            var responsemessage2 = await client2.GetAsync("http://localhost:5100/api/DashboardWidgets/BookingCount");
            var jsonData2 = await responsemessage2.Content.ReadAsStringAsync();
            ViewBag.bookingCount = jsonData2;

            var client3 = _httpClientFactory.CreateClient();
            var responsemessage3 = await client3.GetAsync("http://localhost:5100/api/DashboardWidgets/AppUserCount");
            var jsonData3 = await responsemessage3.Content.ReadAsStringAsync();
            ViewBag.userCount = jsonData3;


            var client4 = _httpClientFactory.CreateClient();
            var responsemessage4 = await client4.GetAsync("http://localhost:5100/api/DashboardWidgets/GetRoomCount");
            var jsonData4 = await responsemessage4.Content.ReadAsStringAsync();
            ViewBag.roomCount = jsonData4;

            return View();
        }
    }
}
