using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoryBook.Data;
using StoryBook.Models.Dto;

namespace StoryBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] 

     public class CreateController : ControllerBase
     {
         private readonly StoryBookDbContext _dbContext;

        public CreateController(StoryBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }
         
         [HttpGet("get-preferences")]
         public async Task<ActionResult<IEnumerable<GetPreferencesDto>>> GetPreferences()
        {
           try
           {
            var userId = User.FindFirst(ClaimTypes.Email)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
              return Unauthorized("User ID is missing or invalid.");
            }
            var userProfile= await _dbContext.UserProfiles.FirstOrDefaultAsync(up => up.ApplicationUser!.Email == userId);
            if (userProfile == null)
            {
              return NotFound ("userid not found");
            }    
            var userGroup = await _dbContext.UserGroups
            .Where(ug => ug.UserId == userProfile.UserId && ug.AgeGroupId > 0)
              .Select(ug => new GetPreferencesDto
            {
                UserId = ug.UserId,
                UserGroupId = ug.UserGroupId,
                ThemeId = ug.ThemeId,
                AgeId = ug.AgeGroupId,
                ThemeName = _dbContext.Themes
                    .Where(t => t.ThemeId == ug.ThemeId)
                    .Select(t => t.ThemeName)
                    .FirstOrDefault() ?? "Unknown Theme",
                GroupName = _dbContext.AgeGroups
                    .Where(ag => ag.AgeGroupId == ug.AgeGroupId)
                    .Select(ag => ag.GroupName)
                    .FirstOrDefault() ?? "Unknown Group Name",
                Images = (ug.AgeGroupId == 1) ? _dbContext.Images
                    .Where(img => img.ThemeId == ug.ThemeId)
                    .Select(img => new ImageDto
                    {
                        Images = img.ImageUrl,
                        ImagesDesc = img.ImageDesc
                    }).ToList()
                : new List<ImageDto>()
            })
            .FirstOrDefaultAsync();  

        if (userGroup == null)
        {
            return NotFound("No preferences found.");
        }

        return Ok(userGroup);
    }
        catch (Exception)
        {
           return StatusCode(500, "An error occurred while retrieving data.");
        }
        }
      
      }
}