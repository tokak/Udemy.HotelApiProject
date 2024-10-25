using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.ContactDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Contact2Controller : ControllerBase
    {
        private readonly IContactService _contactService;
        public Contact2Controller(IContactService contactService)
        {
            _contactService = contactService;
        }
        [HttpPost]
        public IActionResult AddContact(CreateContactDto contact)
        {
            var contactValue = new Contact()
            {
                Date = DateTime.Now,
                Mail = contact.Mail,
                Message = contact.Message,
                MessageCategoryID = contact.MessageCategoryID,
                Name = contact.Name,
                Subject = contact.Subject,
                              

            };

            _contactService.TInsert(contactValue);
            return Ok();
        }
        [HttpGet]
        public IActionResult InboxListContact()
        {
            var values = _contactService.TGetList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetSendMessage(int id)
        {
            var values = _contactService.TGetByID(id);
            return Ok(values);
        }
        [HttpGet("GetContactCount")]
        public IActionResult GetContactCount()
        {
            return Ok(_contactService.TGetContactCount());
        }
    }
}
