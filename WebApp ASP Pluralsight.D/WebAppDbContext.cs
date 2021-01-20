using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApp_ASP_Pluralsight.core;

namespace WebApp_ASP_Pluralsight.D
{
    public class WebAppDbContext:DbContext
    {
        public WebAppDbContext(DbContextOptions<WebAppDbContext> options) : base(options)
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
