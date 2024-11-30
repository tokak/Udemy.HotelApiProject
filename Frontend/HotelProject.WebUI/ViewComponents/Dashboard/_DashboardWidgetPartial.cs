using HotelProject.WebUI.Dtos.RoomDto;
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
            var responseMessage = await client.GetAsync("http://localhost:5039/api/DashboardWidgets/StaffCount");

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                //var values = JsonConvert.DeserializeObject<List<ResultRoomDto>>(jsonData);
                ViewBag.staffcount = jsonData;
            //return View(values);

            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("http://localhost:5039/api/DashboardWidgets/BookingCount");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.bookingcount = jsonData2;

            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("http://localhost:5039/api/DashboardWidgets/AppUserCount");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.appusercount = jsonData2;

            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client2.GetAsync("http://localhost:5039/api/DashboardWidgets/RoomCount");
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.roomcount = jsonData2;

            return View();
        }
    }
}
