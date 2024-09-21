using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApi.Consume.Models;
using System.Net.Http.Headers;
namespace RapidApi.Consume.Controllers
{
    public class BookingController : Controller
    {
        public async Task<IActionResult> Index()
        
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com15.p.rapidapi.com/api/v1/hotels/searchDestination?query=man"),
                Headers =
    {
        { "x-rapidapi-key", "39fce84202msh736411f31a4ca64p16c608jsnc5b12e3cde0f" },
        { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<BookingApiVM>(body);
                return View(values.data.ToList());
            }

        }
    }
}

