using HotelProject.WebUI.Dtos.ServiceDto;
using HotelProject.WebUI.Dtos.SubscribeDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult _SubscribePartial()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> _SubscribePartial(CreateSubscribeDto createSubscribe)
        {
       
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(createSubscribe);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            await client.PostAsync("http://localhost:5100/api/Subscribe", content);
            
            return RedirectToAction("Index","Default");
            
           
        }
    }
    
}
