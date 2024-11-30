using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.RoleDto;
using HotelProject.WebUI.Models.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var roles =  _roleManager.Roles.ToList(); // Retrieves all roles
            return View(roles);
        }

        [HttpGet]
        public async Task<IActionResult> AddRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(AddRoleVm addRoleVm)
        {
            AppRole appRole = new AppRole()
            {
                Name = addRoleVm.Name
            };
            var result = await _roleManager.CreateAsync(appRole);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteRole(int id)
        {

            var value = await _roleManager.FindByIdAsync(id.ToString());
            var result = await _roleManager.DeleteAsync(value);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRole(int id)
        {
            var value = await _roleManager.FindByIdAsync(id.ToString());
            return View(value);
        }
        [HttpPost] 
        public async Task<IActionResult> UpdateRole(UpdateRoleDto updateRoleDto)
        {
            var value = await _roleManager.FindByIdAsync(updateRoleDto.Id.ToString());
            value.Name = updateRoleDto.Name;
            var result = await _roleManager.UpdateAsync(value);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
