using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Real_Estate.Models;

namespace Real_Estate.Data
{
    public class RealEDbContext: IdentityDbContext<ApplicationUser>
    {
        public RealEDbContext(DbContextOptions<RealEDbContext> options):base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False
            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=RealEDb; Integrated Security=True;";
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.RolesSeed();
            builder.UserSeed();
            builder.UserRoleSeed();
            base.OnModelCreating(builder);
        }
        public DbSet<EstateProperty> EstateProperties { get; set; }
        public DbSet<Appointment>Appointments { get; set; } 
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }

}
