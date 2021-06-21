using Microsoft.AspNetCore.Mvc;
using SiteManagementProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteManagementProject.ViewComponents
{
    public class RoleGetList : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            RoleRepository roleRepository = new RoleRepository();
            var roleName = roleRepository.List(x => x.Id == id).Select(x=>x.Name).FirstOrDefault();
            return View(roleName);
        }
    }
}
