using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using Real_Estate.Models;
using System.Xml.Linq;

namespace Real_Estate.Data
{
    public static class REDbInitializer 
    {
      public static void RolesSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
           new IdentityRole{
                Id = "fb63abec-98f5-448e-8f56-302fafd16df4",
                Name = "Admin",
                NormalizedName = "ADMIN",
            },
            new IdentityRole
            {
                Id = "5c965850-234a-4d90-9c24-024ebfac6f20",
                Name = "Client",
                NormalizedName = "CLIENT",
            },
             new IdentityRole
             {
                Id = "51d0771e-de96-4882-a01e-8f0b9949e90c",
                Name = "Owner",
                NormalizedName = "OWNER",
            }
            );
        }
       public static void UserSeed(this ModelBuilder modelBuilder)
        {
            string defaultPassword = "P@ssword123";

            var passwordHasher = new PasswordHasher<ApplicationUser>();
            modelBuilder.Entity<ApplicationUser>().HasData(
          new ApplicationUser
          {
              Id = "f0fbf9f0-eb17-4c87-9c76-9de5451f74ae",
              Name = "Admin",
              Age = 23,
              Address = "Laguna",
              DOB = DateTime.Now,
              UrlImages = "https://www.clipartmax.com/png/middle/319-3191274_male-avatar-admin-profile.png",
              UserName = "admin@gmail.com",
              NormalizedUserName = "admin@gmail.com".ToUpper(),
              NormalizedEmail= "admin@gmail.com".ToUpper(),
              Email = "admin@gmail.com",
              PasswordHash = passwordHasher.HashPassword(null, defaultPassword)
          }
           );
        }
        public static void UserRoleSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "fb63abec-98f5-448e-8f56-302fafd16df4",
                    UserId = "f0fbf9f0-eb17-4c87-9c76-9de5451f74ae"
                }
            );
        }




        /* public static void Seed(IApplicationBuilder applicationBuilder)
         {
             using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
             {
                 var context = serviceScope.ServiceProvider.GetService<RealEstateDbContext>();
                 context.Database.EnsureCreated();

                 if (!context.PropertyTypes.Any())
                 {
                     context.PropertyTypes.AddRange(new List<PropertyTypes>
                     {
                         new PropertyTypes()
                         {
                             Name="Sale",
                             Description="Sale Description"
                         },
                         new PropertyTypes()
                         {
                             Name="Rent",
                             Description="Per Month"
                         },

                     });
                     context.SaveChanges();
                 }
                 //Properties
                 if (!context.Properties.Any())
                 {
                     context.Properties.AddRange(new List<Property>()
                     {
                         new Property()
                         {
                             Name = "Congpound",
                             Description = "Sample Description",
                             Address = "Philippines",
                             UrlImages = "https://cf.bstatic.com/xdata/images/hotel/max1280x900/130486568.jpg?k=57fb350c65182db72d4dd5bdfe3a0aca2a1002af2d114940dba6b578f6f65ff5&o=&hp=1",
                             PriceifSale = 200.00,
                             PriceifRent =20.00,
                             PropertytypesID = 1, 
                         },
                          new Property()
                         {
                             Name = "Payamansyon",
                             Description = "Sample Description",
                             Address = "Philippines",
                             UrlImages = "https://cf.bstatic.com/xdata/images/hotel/max1280x900/130486573.jpg?k=847a193089fc0eecd7766e98e4760973549bf2af9345266f8e1d390a2460b987&o=&hp=1",
                             PriceifSale = 200.00,
                             PriceifRent =20.00,
                             PropertytypesID = 1,
                          },
                            new Property()
                         {
                             Name = "Congdo",
                             Description = "Sample Description",
                             Address = "Philippines",
                             UrlImages ="https://cf.bstatic.com/xdata/images/hotel/max1280x900/236280245.jpg?k=2d914b6e79def9a29144d26df9c14b677c425f4255b4899d3cd750eb7f41a86a&o=&hp=1",
                             PriceifSale = 200.00,
                             PriceifRent =20.00,
                             PropertytypesID = 1
                         }
                     }); 
                     context.SaveChanges();
                 }

             }

             }
         }*/
    }
}
    

