﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MTBEventProject.Security
{
    public class AppIdentityDbContext : IdentityDbContext<AppIdentityUser, AppIdentityRole, string>
    {
        public AppIdentityDbContext
            (DbContextOptions<AppIdentityDbContext> options)
            : base(options)
        {
        }
    }

}
