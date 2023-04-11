using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstateApi.Data;
using RealEstateApi.Models;

namespace RealEstateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //private readonly UserManager<ApplicationUser> _userManager;
        private readonly RealEstateDbContext _context;

        /* public UsersController(UserManager<ApplicationUser> userManager, RealEstateDbContext context)
         {
             _userManager = userManager;
             _context = context;
        public UsersController(RealEstateDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }*/

    }
}
