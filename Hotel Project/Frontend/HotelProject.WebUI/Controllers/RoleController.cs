﻿using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Models.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _rolemanager;

        public RoleController(RoleManager<AppRole> rolemanager)
        {
            _rolemanager = rolemanager;
        }

        public IActionResult Index()
        {
            var values = _rolemanager.Roles.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddRole() 
        {
            return View();  
        }
        [HttpPost]
        public async Task <IActionResult> AddRole(AddRoleViewModel addRoleViewModel)
        {
            AppRole appRole = new AppRole()
            {
                Name = addRoleViewModel.RoleName
            };
            var result = await _rolemanager.CreateAsync(appRole);
            if(result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
        public async Task<IActionResult> DeleteRole(int id)
        {
            var value = _rolemanager.Roles.FirstOrDefault(x=>x.Id == id);
            await _rolemanager.DeleteAsync(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            var value = _rolemanager.Roles.FirstOrDefault(x=>x.Id==id);
            UpdateRoleViewModel updateRoleViewModel = new UpdateRoleViewModel()
            {
                RoleId = value.Id,
                RoleName = value.Name,
            };
            return View(updateRoleViewModel);
        }
        [HttpPost] 
        public async Task<IActionResult> UpdateRole(UpdateRoleViewModel updateRoleViewModel)
        {
            var value = _rolemanager.Roles.FirstOrDefault(x=>x.Id==updateRoleViewModel.RoleId);
            value.Name = updateRoleViewModel.RoleName;
            await _rolemanager.UpdateAsync(value);
            return RedirectToAction("Index");
        }
    }
}
