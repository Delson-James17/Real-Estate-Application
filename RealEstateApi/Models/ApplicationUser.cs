using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace RealEstateApi.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public DateTime? DOB { get; set; }
        public string UrlImages { get; set; }
        public string? Zoomlink { get; set; }
    
        public List<Property>Properties { get; set; }
    }
}
