using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Real_Estate.Data;
using Real_Estate.Models;
using Real_Estate.ViewModels;
using System.Security.Claims;

namespace Real_Estate.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RealEDbContext _context;

        public UsersController(UserManager<ApplicationUser> userManager, RealEDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            return View(users);
        }
        public IActionResult Details(string userId)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Id == userId);
            return View(user);
        }
        public async Task<IActionResult> Delete(string userId)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Id == userId);
            var userlist = await _userManager.DeleteAsync(user);
            return RedirectToAction(controllerName: "Users", actionName: "GetAllUsers"); // reload the getall page it self
        }
       

        [HttpGet]
        public async Task<IActionResult> Update(string userId)
        {
            var users = _userManager.Users.FirstOrDefault(u => u.Id == userId);
            var roles = await _userManager.GetRolesAsync(users);
            EditUserViewModel userViewModel = new EditUserViewModel()
            {  
                Name= users.Name,
                Age= users.Age,
                Address= users.Address, 
                DOB = (DateTime)users.DOB,
                PhoneNumber = users.PhoneNumber,
                UrlImages = users.UrlImages,
                Zoomlink = users.Zoomlink,
                UserName = users.UserName,
                Email = users.Email,
                Roles = roles

            };
            return View(userViewModel);
        }
        
        [HttpPost]
        public async Task<IActionResult> Update(EditUserViewModel user)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            ApplicationUser? userProfile = await _context.ApplicationUsers.FindAsync(userId);

            userProfile.Name = user.Name;
            userProfile.Age = user.Age;
            userProfile.Address = user.Address;
            userProfile.Email = user.Email;
            userProfile.DOB = user.DOB;
            userProfile.Zoomlink = user.Zoomlink;
            userProfile.UserName = user.UserName;
            userProfile.PhoneNumber = user.PhoneNumber;

            int value = await _context.SaveChangesAsync();
            return RedirectToAction("GetAllUsers");
        }
       
        }
    

    }

