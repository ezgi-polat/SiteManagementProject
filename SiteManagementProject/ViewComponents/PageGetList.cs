using Microsoft.AspNetCore.Mvc;
using SiteManagementProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteManagementProject.ViewComponents
{
    public class PageGetList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            PageRepository pageRepository = new PageRepository();
            var pageList = pageRepository.TList();
            return View(pageList);
        }
    }
}
