
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealEstateApi.Models;

namespace RealEstateApi.Data
{
    public class RealEstateDbContext : IdentityDbContext<ApplicationUser>
    {
        public RealEstateDbContext(DbContextOptions<RealEstateDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=ReDB;Integrated Security=True;";
           optionsBuilder.UseSqlServer(connectionString)
           .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
           base.OnConfiguring(optionsBuilder);
        }
       

        public DbSet<Property> Properties { get; set; }

        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<ApplicationUser> Userprofiles { get; set; }
    }
}
