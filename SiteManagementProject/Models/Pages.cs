using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiteManagementProject.Models
{
    public class Pages
    {
        [Key]
        public int PageId { get; set; }
        public string PageName { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public string ImageUrl { get; set; }
        public int MenuId { get; set; }
        public virtual Menu Menu { get; set; }

    }
}
