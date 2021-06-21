using Microsoft.AspNetCore.Mvc;
using SiteManagementProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteManagementProject.ViewComponents
{
    public class PageCategoryGetList : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            PageRepository pageRepository = new PageRepository();
            var pageList = pageRepository.List(x => x.MenuId == id);
            return View(pageList);
        }
    }
}
