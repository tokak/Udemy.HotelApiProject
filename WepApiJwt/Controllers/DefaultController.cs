using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WepApiJwt.Models;

namespace WepApiJwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet("[action]")]
        public IActionResult Test()
        {
            return Ok(new CreateToken().TokenCreate());
        }

        [Authorize]
        [HttpGet("[action]")]
        public IActionResult Test2()
        {
            return Ok("Hoşgeldiniz");
        }

        [HttpGet("[action]")]
        public IActionResult AdminTokenOlustur()
        {
            return Ok(new CreateToken().TokenCreateAdmin());
        }

        [Authorize(Roles = "Admin,Visitor")]
        [HttpGet("[action]")]
        public IActionResult Test3()
        {
            return Ok("Token Başarılı Bir Şekilde Giriş Yaptı");
        }
    }
}
