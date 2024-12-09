using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Internet1_RentACar.Models
{
    public class AppDbContext : IdentityDbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Category> Categories{ get; set; } 
        public DbSet<Car> Cars{ get; set; }
        public DbSet<Renting> Rentings { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }



    }
}
