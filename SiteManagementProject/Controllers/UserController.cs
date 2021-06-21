using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SiteManagementProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteManagementProject.Controllers
{
  
    public class UserController : Controller
    {
      
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        public UserController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Index()
        {
           
                return View();
           
        }
    
        public IActionResult KayitOl()
        {
            return View(new UserSignUpViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> KayitOl(UserSignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                   
                    Name = model.Name,
                   
                    UserName = model.UserName


                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

       
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> GirisYap(UserSignInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var identityResult = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, true);

                if (identityResult.IsLockedOut)
                {
                    var gelen = await _userManager.GetLockoutEndDateAsync(await _userManager.FindByNameAsync(model.UserName));
                    var kisitlananSure = gelen.Value;

                    var kalanDakika = kisitlananSure.Minute - DateTime.Now.Minute;

                    ModelState.AddModelError("", $"3 kere yanlış girdiğiniz için hesabınız {kalanDakika} dk kilitlenmiştir ");
                    return View("Index", model);

                }
                if (identityResult.IsNotAllowed)
                {
                    ModelState.AddModelError("", "Email adresinizi lütfen doğrulayın");
                    return View("Index", model);
                }
                if (identityResult.Succeeded)
                {                  
                    var user = await _userManager.FindByNameAsync(model.UserName);
                    var rolesList = await _userManager.GetRolesAsync(user);
                    if (rolesList.Count>0)
                    {
                        ViewBag.id = 1;
                    }
                    else
                    {
                        ViewBag.id = 1;
                    }
                    return RedirectToAction("GetLogin", "Home",model);
                }
                else
                {
                    ModelState.AddModelError("", "kullanıcı adı ve şifre hatalı ");
                    return View("index", model);
                }
                var yanlisGirilmeSayisi = await _userManager.GetAccessFailedCountAsync(await _userManager.FindByNameAsync(model.UserName));

                ModelState.AddModelError("", $"Kullanıcı adı ve şifre hatalı {5 - yanlisGirilmeSayisi} kadar yanlış girerseniz hesabınız bloklanacaktır");
            }
            return View("Index", model);
        }
        public async Task<IActionResult> UpdateUser()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            User model = new User()
            {
               
                Name = user.Name,
                SurName = user.SurName
          
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUser(User model)
        {

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
             
                user.Name = model.Name;
                user.SurName = model.SurName;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(model);
        }
      [AllowAnonymous]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "User");
        }
    }
}
