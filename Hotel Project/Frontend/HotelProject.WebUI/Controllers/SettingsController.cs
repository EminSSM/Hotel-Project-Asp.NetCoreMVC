using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Models.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
            
                var userName = User.Identity.Name;
                var user = await _userManager.FindByNameAsync(userName);

                UserEditViewModel userEditViewModel = new UserEditViewModel();
                userEditViewModel.Name = user.Name;
                userEditViewModel.Surname = user.Surname;
                userEditViewModel.Username = user.UserName;
                userEditViewModel.Email = user.Email;
                return View(userEditViewModel);
          
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel userEditViewModel)
        {
            if(userEditViewModel.Password == userEditViewModel.ConfirmPassword)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.Name = userEditViewModel.Name;
                user.Surname = userEditViewModel.Surname;
                user.Email = userEditViewModel.Email;
                user.UserName = userEditViewModel.Username;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditViewModel.Password);
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Login");

            }
            return View();
          
        }
    }
}
