using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SiteManagementProject.Models;
using SiteManagementProject.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SiteManagementProject.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        public HomeController(RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        MenuRepositories _menuRepositories = new MenuRepositories();

        
        public IActionResult Index()
        {
            return View(_menuRepositories.TList());
        }
       
        public IActionResult AccessDenied()
        {
            return View();
        }
        [AllowAnonymous]
        public async Task<IActionResult> GetLogin(UserSignInViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);

            return View(user);
        }
     
        public IActionResult MenuDetails(int id)
        {
            ViewBag.id = id;
            return View();
        }
     
        public IActionResult GetPage(int id)
        {
            
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            //await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "User");
        }
    }
}
