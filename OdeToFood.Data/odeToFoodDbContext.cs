using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Data
{
    public class odeToFoodDbContext: DbContext
    { 

        public odeToFoodDbContext(DbContextOptions<odeToFoodDbContext> options): base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Restaurant> restaurants { get; set; }
    }
}
