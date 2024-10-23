using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace HotelProject.WebUI.ViewComponents.SideBarAdminContact
{
    public class _SideBarAdminContactPartial: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _SideBarAdminContactPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
       {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5039/api/Contact/GetContactCount");

            var responseMessage2 = await client.GetAsync("http://localhost:5039/api/SendMessage/GetSendMessageCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                ViewBag.contactCount = jsonData;
                ViewBag.sendMessageCount = jsonData2;
                return View();
            }
            return View();
        }
    }
}
