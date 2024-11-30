using HotelProject.DataAccessLayer.Abstract;
using HotelProject.WebUI.Dtos.StaffDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardLast4StaffList : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardLast4StaffList(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5039/api/Staff/Last4Staff");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultStaffDto>>(jsonData);
            return View(values);
        }
    }
}
