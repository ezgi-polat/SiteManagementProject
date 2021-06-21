using Microsoft.AspNetCore.Mvc;
using SiteManagementProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteManagementProject.ViewComponents
{
    public class MenuGetList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            MenuRepositories menuRepository = new MenuRepositories();
            var menuList = menuRepository.TList();
            return View(menuList);
        }
    }
}
