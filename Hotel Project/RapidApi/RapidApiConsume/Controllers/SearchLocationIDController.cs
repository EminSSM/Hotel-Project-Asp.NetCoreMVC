using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Newtonsoft.Json;
using RapidApiConsume.Models;

namespace RapidApiConsume.Controllers
{
    public class SearchLocationIDController : Controller
    {
        public async Task<IActionResult> Index(string cityName)
        {
            if (!string.IsNullOrEmpty(cityName))
            {
                List<BookingSearchLocationViewModel> searchLocations = new List<BookingSearchLocationViewModel>();
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={cityName}&locale=en-gb"),
                    Headers =
    {
        { "X-RapidAPI-Key", "0da3b7bb0amsha692bfc3feef79fp117bcejsn31bc0893481a" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    searchLocations = JsonConvert.DeserializeObject<List<BookingSearchLocationViewModel>>(body);
                    return View(searchLocations.Take(1).ToList());
                }
                
            }
            else
            {
                List<BookingSearchLocationViewModel> searchLocations = new List<BookingSearchLocationViewModel>();
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/locations?name=Paris&locale=en-gb"),
                    Headers =
    {
        { "X-RapidAPI-Key", "0da3b7bb0amsha692bfc3feef79fp117bcejsn31bc0893481a" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    searchLocations = JsonConvert.DeserializeObject<List<BookingSearchLocationViewModel>>(body);
                    return View(searchLocations.Take(1).ToList());
                }
            }
           
        }
    }
}
