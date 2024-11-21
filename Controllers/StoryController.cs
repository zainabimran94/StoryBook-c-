using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoryBook.Data;
using StoryBook.Models;


namespace StoryBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoryController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
         private readonly StoryBookDbContext _dbContext;
        public StoryController(IHttpClientFactory httpClientFactory, StoryBookDbContext dbContext)
    {
        _httpClientFactory = httpClientFactory;
         _dbContext = dbContext;
    }

    [HttpPost("generate-story")]
public async Task<IActionResult> GenerateStory([FromBody] SendPreferencesDto select)
{
    try
    {
        var userProfile= await _dbContext.UserProfiles.FindAsync(select.UserId);
            if (userProfile == null)
            {
               return NotFound ("userid not found");
            }    

        var userGroup = await _dbContext.UserGroups
            .Include(ug => ug.AgeGroup)
            .Include(ug => ug.Theme)
            .Where(ug => ug.AgeGroup!.GroupName == select.GroupName && ug.Theme!.ThemeName == select.ThemeName)
            .FirstOrDefaultAsync();

        if (userGroup == null)
        {
            return NotFound("No matching user group, age group, or theme found.");
        }
         var isToddlerGroup = userGroup.AgeGroupId == 1; 
         var selectPreference = new UserPreference
         {
            UserId = userProfile.UserId,
            GroupName = userGroup.AgeGroup!.GroupName,
            ThemeName = userGroup.Theme!.ThemeName,
            ImageDesc = isToddlerGroup ? select.ImageDesc : null,
            StoryDesc = !isToddlerGroup ? select.StoryDesc : null,
         };
             _dbContext.UserPreferences.Add(selectPreference);
             await _dbContext.SaveChangesAsync();

        var dataToSend = new SendPreferencesDto
        {
            GroupName = userGroup.AgeGroup!.GroupName,
            ThemeName = userGroup.Theme!.ThemeName,
            ImageDesc = select.ImageDesc,
            StoryDesc = select.StoryDesc,
            UserId = userProfile.UserId
        };

         var options = new JsonSerializerOptions
          {
            PropertyNameCaseInsensitive = true,
             AllowTrailingCommas = true
          };  

        // Creating the HTTP client and sending request to the Python API
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonSerializer.Serialize(dataToSend, options);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

        // Make sure 'response' is declared here to avoid scope issues
        var response = await client.PostAsync("http://127.0.0.1:8000/api/generate-story", content);
        response.EnsureSuccessStatusCode();

        // Read the response content
         var generatedStoryJson = await response.Content.ReadAsStringAsync();
        if (string.IsNullOrWhiteSpace(generatedStoryJson))
        {
            return BadRequest("Failed to parse story data.");
        }
        var generatedStory = JsonSerializer.Deserialize<StoryGeneratedDto>(generatedStoryJson);
        if (generatedStory == null)
        {
            return BadRequest("Failed to parse story data.");
        }
        
        // Return a success response if everything went well
        return Ok("Story created and saved successfully.");
    }
    catch (JsonException jsonEx)
    {
        // Log and return specific deserialization errors
        Console.WriteLine($"JSON Deserialization Error: {jsonEx.Message}");
        return StatusCode(500, $"JSON Error: {jsonEx.Message}");
    }
    catch (DbUpdateException dbEx)
    {
        // Log and return specific database errors
        Console.WriteLine($"Database Update Error: {dbEx.Message}");
        return StatusCode(500, $"Database Error: {dbEx.Message}");
    }
    catch (Exception)
    {
        return StatusCode(500, "An error occurred when sending or saving the story.");
    }
}

    [HttpPost("create-story")]
     public async Task<IActionResult>CreatedStory([FromBody] StoryGeneratedDto select)
     {
        try
        {
          
          var userProfile= await _dbContext.UserProfiles.FindAsync(select.UserId);
            if (userProfile == null)
            {
               return NotFound ("userid not found");
            }    
           var createdStory = new PythonData
           {
                StoryGenTitle = select.StoryGenTitle ?? string.Empty,
                StoryBook = select.StoryBook ?? string.Empty,
                StoryImageUrl = select.StoryImageUrl ?? string.Empty,
                UserId = userProfile.UserId
              
            };
              _dbContext.PythonData.Add(createdStory);
               await _dbContext.SaveChangesAsync();
               return Ok ("story created");
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occured when getting story");
        }
     }


    
}
}