using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Models.Setting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class SettingsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SettingsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditVM vm = new UserEditVM();
            vm.Name = user.Name;
            vm.Surname = user.Surname;
            vm.Email = user.Email;
            vm.Username = user.UserName;
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditVM userEditVM)
        {
            if (userEditVM.Password == userEditVM.ConfirmPassword)
            {
                var user = await _userManager.FindByEmailAsync(User.Identity.Name);
                user.Name = userEditVM.Name;
                user.Surname = userEditVM.Surname;
                user.Email = userEditVM.Email;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditVM.Password);
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Login");
            }
            return View(userEditVM);
        }
    }
}
