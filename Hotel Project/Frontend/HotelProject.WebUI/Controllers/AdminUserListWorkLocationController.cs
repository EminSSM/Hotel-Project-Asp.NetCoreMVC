using HotelProject.WebUI.Dtos.AppUserDto;
using HotelProject.WebUI.Dtos.WorkLocationDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.Controllers
{
    public class AdminUserListWorkLocationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminUserListWorkLocationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("http://localhost:5100/api/AppUserWorkLocation");
            if (responsemessage.IsSuccessStatusCode)
            {
                var jsonData = await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<UserListWorkLocationDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
