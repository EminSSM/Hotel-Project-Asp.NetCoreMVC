using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.AboutDto;
using HotelProject.WebUI.Dtos.AppUserDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.Controllers
{
    public class AdminUsersController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public AdminUsersController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        //public async Task<IActionResult> Index()
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var responsemessage = await client.GetAsync("http://localhost:5100/api/AppUser");
        //    if (responsemessage.IsSuccessStatusCode)
        //    {
        //        var jsonData = await responsemessage.Content.ReadAsStringAsync();
        //        var values = JsonConvert.DeserializeObject<List<ResultUserDto>>(jsonData);
        //        return View(values);
        //    }
        //    return View();
        //}
        public async Task<IActionResult> UserList()
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("http://localhost:5100/api/AppUser");
            if (responsemessage.IsSuccessStatusCode)
            {
                var jsonData = await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultUserListDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
