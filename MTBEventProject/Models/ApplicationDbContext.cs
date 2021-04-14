using System;
using Microsoft.EntityFrameworkCore;

namespace MTBEventProject.Models
{
    public class ApplicationDbContext: DbContext
    {

         public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
            {
            }

        public DbSet<MTBEvent> MTBEvents { get; set; } 
    }
}
