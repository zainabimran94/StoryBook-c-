using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoryBook.Data;
using StoryBook.Models;
using StoryBook.Models.Dto;



namespace StoryBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] 
    public class SelectionController : ControllerBase
    {
        private readonly StoryBookDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public SelectionController( UserManager<ApplicationUser> userManager, StoryBookDbContext dbContext)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        
        [HttpGet("agegroups")]
        public async Task<ActionResult<IEnumerable<AgeGroupDto>>> GetAgeGroups()
        {
            var ageGroups = await _dbContext.AgeGroups
                .Select(ag => new AgeGroupDto
                {
                    AgeGroupId = ag.AgeGroupId,
                    GroupName = ag.GroupName
                })
                .ToListAsync();

            return Ok(ageGroups);
        }

       
        [HttpGet("themes")]
        public async Task<ActionResult<IEnumerable<ThemeDto>>> GetThemes()
        {
            var themes = await _dbContext.Themes
                .Select(t => new ThemeDto
                {
                    ThemeId = t.ThemeId,
                    ThemeName = t.ThemeName
                })
                .ToListAsync();

            return Ok(themes);
        }

        [HttpPost("UserGroup")]
        public async Task<IActionResult>SelectGroup([FromBody] UserGroupDto select)
        {
            try 
            {
               
               var userId= await _dbContext.UserProfiles.FindAsync(select.UserId);
               if (userId == null)
               {
                return NotFound ("userid not found");
               }            
               var ageGroup = await _dbContext.AgeGroups.FindAsync(select.AgeGroupId);
               var themeGroup = await _dbContext.Themes.FindAsync(select.ThemeId);

               if (ageGroup == null)
               {
                return NotFound("Age-Group not found");
               }
               if (themeGroup == null)
               {
                return NotFound("theme-Group not found");
               }
               var userGroup = new UserGroup
               {
                UserId = select.UserId,
                AgeGroupId = select.AgeGroupId,
                ThemeId = select.ThemeId,
               
               };
               _dbContext.UserGroups.Add(userGroup);
               await _dbContext.SaveChangesAsync();

               return Ok("Group added successfully");
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occured when adding group");
            }
        }

        


    }
}