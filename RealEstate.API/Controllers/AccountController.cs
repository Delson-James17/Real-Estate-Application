using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using RealEstate.API.DTO;
using RealEstate.API.Models;
using RealEstate.API.Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace RealEstate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public IConfiguration _appConfig { get; }
        public IMapper _mapper { get; }

        IAccountRepository _repo;
        public AccountController(IAccountRepository accRepo, IMapper mapper, IConfiguration appConfig)
        {
            _repo = accRepo;
            _mapper = mapper;
            _appConfig = appConfig;
        }
        [HttpPost("signup")]

        public async Task<IActionResult> Register(RegisterUserDto registerUserDto)
        {
            var user = _mapper.Map<ApplicationUser>(registerUserDto);

            var val = await _repo.SignUpUserAsync(user, registerUserDto.Password);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDto loginUserDto)
        {
            var issuer = _appConfig["JWT:Issuer"];
            var audience = _appConfig["JWT:Audience"];
            var key = _appConfig["JWT:Key"];

            if (ModelState.IsValid)
            {
                var loginResult = await _repo.SignInUserAsync(loginUserDto);
                if (loginResult.Succeeded)
                {
                    // generate a token
                    var user = _repo.FindUserByEmailAsync(loginUserDto.Email);
                    if (user != null)
                    {
                        var keyBytes = Encoding.UTF8.GetBytes(key);
                        var theKey = new SymmetricSecurityKey(keyBytes); // 256 bits of key
                        var creds = new SigningCredentials(theKey, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(issuer, audience, null, expires: DateTime.Now.AddMinutes(30), signingCredentials: creds);
                        return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) }); // token 
                    }


                }
            }
            return BadRequest();
        }
    }
}
   
