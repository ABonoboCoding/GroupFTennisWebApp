﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupFTennisWebApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GroupFTennisWebApp.Models;

namespace GroupFTennisWebApp.Data
{
    public class GroupFTennisWebAppContext : IdentityDbContext<GroupFTennisWebAppUser>
    {
        public GroupFTennisWebAppContext(DbContextOptions<GroupFTennisWebAppContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<GroupFTennisWebApp.Models.Coach> Coach { get; set; }

        public DbSet<GroupFTennisWebApp.Models.Schedule> Schedule { get; set; }

        public DbSet<GroupFTennisWebApp.Models.ScheduleMembers> ScheduleMembers { get; set; }
    }
}

/* Commands:
            dotnet tool install --global dotnet-ef 

            dotnet ef migrations add InitialCreate   -- creates script 

             

            dotnet ef database update  -- creates db and runs the migration 

             

            dotnet ef migrations remove 

            dotnet ef database drop 
         */
