using HotelProject.WebUI.Dtos.FollowDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardSubscribePartial : ViewComponent
    {
        public async Task <IViewComponentResult> InvokeAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://instagram-profile1.p.rapidapi.com/getprofile/murattycedag"),
                Headers =
    {
        { "X-RapidAPI-Key", "0da3b7bb0amsha692bfc3feef79fp117bcejsn31bc0893481a" },
        { "X-RapidAPI-Host", "instagram-profile1.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                ResultInstagramFollowDto resultInstagramFollowDto = JsonConvert.DeserializeObject<ResultInstagramFollowDto>(body);
                ViewBag.v1 = resultInstagramFollowDto.followers;
                ViewBag.v2 = resultInstagramFollowDto.following;

            }

            var client2 = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://twitter32.p.rapidapi.com/getProfile?username=murattyucedag"),
                Headers =
    {
        { "X-RapidAPI-Key", "0da3b7bb0amsha692bfc3feef79fp117bcejsn31bc0893481a" },
        { "X-RapidAPI-Host", "twitter32.p.rapidapi.com" },
    },
            };
            using (var response2 = await client2.SendAsync(request2))
            {
                response2.EnsureSuccessStatusCode();
                var body2 = await response2.Content.ReadAsStringAsync();
                ResultTwitterFollowDto resultTwitterFollowDto = JsonConvert.DeserializeObject<ResultTwitterFollowDto>(body2);
                ViewBag.v3 = resultTwitterFollowDto.data.user_info.followers_count;
                ViewBag.v4 = resultTwitterFollowDto.data.user_info.friends_count;


            }
            var client3 = new HttpClient();
            var request3 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://fresh-linkedin-profile-data.p.rapidapi.com/get-linkedin-profile?linkedin_url=https%3A%2F%2Ftr.linkedin.com%2Fin%2Fmurat-y%25C3%25BCceda%25C4%259F-186933149%3Ftrk%3Dauthor_mini-profile_title%26challengeId%3DAQFGymZ9mN0e2AAAAYi58KS6hm0xvnQlm12RCkPY7Lh9ca2kW9Z8V8FigBKv2ySLfnD2xGiLshlqtV9e7DJIvZNH6Ki16k8iFQ%26submissionId%3D4764a51a-3887-6817-c595-f766444cba36%26challengeSource%3DAgG2xE_MgWnrwQAAAYi58OfMeFKDoCt8QJL8-6p-kgNIAKcaKTz3GWNsV5OkUeI%26challegeType%3DAgEyO-Pt0j-mtwAAAYi58OfPAdQR5vhzHWFU9wtlmAeWXo-uf6mutBM%26memberId%3DAgEFO15tD_uGGAAAAYi58OfS_rRc24o7g3c0BVvcemelYsc%26recognizeDevice%3DAgF5M5H380OBtwAAAYi58OfWY_wbAK6noCK2zPFlTIAkm-P1u23f"),
                Headers =
    {
        { "X-RapidAPI-Key", "0da3b7bb0amsha692bfc3feef79fp117bcejsn31bc0893481a" },
        { "X-RapidAPI-Host", "fresh-linkedin-profile-data.p.rapidapi.com" },
    },
            };
            using (var response3 = await client3.SendAsync(request3))
            {
                response3.EnsureSuccessStatusCode();
                var body3 = await response3.Content.ReadAsStringAsync();
                ResultLinkedinFollowDto resultLinkedinFollow = JsonConvert.DeserializeObject<ResultLinkedinFollowDto>(body3);
                ViewBag.v5 = resultLinkedinFollow.data.followers_count;
            }
            return View();
        }
    }
}
