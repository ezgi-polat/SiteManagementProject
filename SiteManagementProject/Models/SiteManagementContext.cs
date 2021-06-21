using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteManagementProject.Models
{
    public class SiteManagementContext : IdentityDbContext<User,Role, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=S1744; database= SiteManagementDTB; integrated security=true");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
