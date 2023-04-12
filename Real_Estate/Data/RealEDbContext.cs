using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Real_Estate.Models;

namespace Real_Estate.Data
{
    public class RealEDbContext: IdentityDbContext<ApplicationUser>
    {
        public IConfiguration _appConfig { get; }
        public ILogger _logger { get; }
        private readonly IWebHostEnvironment _env;
        public RealEDbContext(IConfiguration appConfig, ILogger<RealEDbContext> logger,
            IWebHostEnvironment env)
        {
            _appConfig = appConfig;
            _logger = logger;
            _env = env;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var server = _appConfig.GetConnectionString("Server");
            var db = _appConfig.GetConnectionString("DB");
            string connectionString;
            if (_env.IsDevelopment())
            {
                connectionString = $"Server={server};Database={db};MultipleActiveResultSets=true";
            }
            else
            {
                var username = _appConfig.GetConnectionString("Username");
                var password = _appConfig.GetConnectionString("Password");
                connectionString = $"Server={server};Database={db};User Id={username};Password={password};Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;";
            }
            optionsBuilder.UseSqlServer(connectionString)
                .UseQueryTrackingBehavior(QueryTrackingBehavior
                .NoTracking);
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
