using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteManagementProject.Models
{
    public class ContextDB : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost; database= SiteManagementDTB; integrated security=true");
        }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Pages> Pages { get; set; }
   

    }
}
