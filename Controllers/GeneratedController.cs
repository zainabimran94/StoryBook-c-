using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoryBook.Data;
using StoryBook.Models;

namespace StoryBook.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class GenerateController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
         private readonly StoryBookDbContext _dbContext;
        public GenerateController(IHttpClientFactory httpClientFactory, StoryBookDbContext dbContext)
    {
        _httpClientFactory = httpClientFactory;
         _dbContext = dbContext;
    }

    [HttpGet("get-story")]
public async Task<ActionResult<IEnumerable<GetStoryDto>>>GetStory()
{
    try
    {
        // Find the user
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
        // Retrieve the story for the user
        var story = await _dbContext.PythonData
            .Where(s => s.UserId == userProfile.UserId)
            .OrderByDescending(s => s.PythonDataId) 
            .Select(s => new GetStoryDto
            {
                UserId = s.UserId,
                StoryGenTitle = s.StoryGenTitle,
                StoryBook = s.StoryBook,
                PythonDataId = s.PythonDataId,
                StoryImageUrl = s.StoryImageUrl
            })
            .ToListAsync();

        if (story == null)
        {
            return NotFound("Story not found for the specified user.");
        }
        return Ok(story);
    }
    catch (Exception)
    {
        return StatusCode(500, "An error occurred while retrieving the story.");
    }
}

    }
}    