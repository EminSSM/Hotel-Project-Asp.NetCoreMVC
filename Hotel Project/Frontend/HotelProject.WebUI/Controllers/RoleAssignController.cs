using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Models.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class RoleAssignController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        public RoleAssignController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var user = _userManager.Users.ToList();
            return View(user);
        }
        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            TempData["userid"] = user.Id;
            var roles = _roleManager.Roles.ToList();
            var userroles = await _userManager.GetRolesAsync(user);
            List<AssignRoleViewModel> assignRoleViewModels = new List<AssignRoleViewModel>();
            foreach (var role in roles)
            {
                AssignRoleViewModel model = new AssignRoleViewModel();
                model.RoleId = role.Id;
                model.RoleName = role.Name;
                model.RoleExist = userroles.Contains(role.Name);
                assignRoleViewModels.Add(model);
            }
            return View(assignRoleViewModels);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRole(List<AssignRoleViewModel> assignRoleViewModel)
        {
            var userId = (int)TempData["userid"];
            var user = _userManager.Users.FirstOrDefault(x=>x.Id==userId );
            foreach (var item in assignRoleViewModel)
            {
                if (item.RoleExist)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);

                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);    
                }
            }
            return RedirectToAction("Index");

        }

    }
}
