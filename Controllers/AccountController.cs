using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoryBook.Data;
using StoryBook.Interfaces;
using StoryBook.Models;
using StoryBook.Models.AuthDto;

namespace StoryBook.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly StoryBookDbContext _dbContext;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ITokenService tokenService,
            StoryBookDbContext dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
             _dbContext = dbContext;
        }

        [HttpPost("register")]
           public async Task<IActionResult>Register([FromBody] RegisterDto model)
        {
               if (!IsValidEmail(model.Email)) 
            {
                 return BadRequest(new { message = "Invalid email format." });
            }

             var existingUser = await _userManager.FindByEmailAsync(model.Email);
             if(existingUser != null )
            {
              return BadRequest(new { message = "Email already exists." });
            }

            var user = new ApplicationUser
            {
                UserName = model.Email,
                FullName = model.Name, 
                 Email = model.Email
            };
    
             var result = await _userManager.CreateAsync(user, model.Password);

              if (result.Succeeded)
            {
                var userProfile = new UserProfile
                {
                    UserId = Guid.NewGuid(), 
                    Email = user.Email,
                    Name = user.FullName,
                    PasswordHash = user.PasswordHash,
                    ApplicationUserId = user.Id,
                    ApplicationUser = user,
                };
                 _dbContext.UserProfiles.Add(userProfile); // Add the UserProfile to the DbContext
                 await _dbContext.SaveChangesAsync();
             return Ok(new { message = "User registered successfully." });
            }

             var errors = result.Errors.Select(e => e.Description);
             return BadRequest(new { message = "Registration failed.", errors });
        }

        [HttpPost("login")]
           public async Task<IActionResult> Login( [FromBody]LoginDto model)
        {
            if (!ModelState.IsValid)
            return BadRequest(ModelState);

            var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    return Unauthorized("Invalid user ID or password");
                }
            var userProfile = await _dbContext.UserProfiles
             .FirstOrDefaultAsync(up => up.ApplicationUserId == user.Id);

           if (userProfile == null)
             {
                return Unauthorized("User profile not found.");
              }

            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (!result.Succeeded) return Unauthorized("Invalid email or password");

             var token = _tokenService.CreateToken(user , userProfile);

            return Ok(new{token});
        }

          private static bool IsValidEmail(string email)
        {
            try
            {
                var address = new System.Net.Mail.MailAddress(email);
                return address.Address == email;
            }
            catch
            {
                return false;
            }
        }

        
    }
}