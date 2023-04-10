using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Real_Estate.Models;

namespace Real_Estate.Data
{
    public class RealEstateDbContext : IdentityDbContext<ApplicationUser>
    {
        public RealEstateDbContext(DbContextOptions<RealEstateDbContext> options) : base(options)
        {
        }

        //public RealEstateDbContext()
        //{
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=ReDB;Integrated Security=True;";
        //    optionsBuilder.UseSqlServer(connectionString)
        //    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        //    base.OnConfiguring(optionsBuilder);
        //}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.RolesSeed();
            builder.UserSeed();
            builder.UserRoleSeed();
            base.OnModelCreating(builder);
        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyTypes> PropertyTypes { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<ApplicationUser> Userprofiles { get; set; }
    }
}
