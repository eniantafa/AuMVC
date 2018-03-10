using AuMVC.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuMVC.Data
{
    public class AppDbContext:IdentityDbContext<IdentityUser>
    {
        

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        
            public DbSet<Site> Sites { get; set; }
            public DbSet<Issue> Issues { get; set; }
            public DbSet<Maintenance> Maintenances { get; set; }
            public DbSet<ProgressStage> ProgressStages { get; set; }
            public DbSet<Variation> Variations { get; set; }
        }
}
