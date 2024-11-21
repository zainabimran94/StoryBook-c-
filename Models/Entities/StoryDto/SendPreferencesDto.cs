using System.Text.Json.Serialization;

namespace StoryBook.Models
{
    public class SendPreferencesDto
    {
         [JsonPropertyName("groupName")]
        public required string GroupName {get; set;}
        [JsonPropertyName("themeName")]
        public required string ThemeName {get; set;}
        [JsonPropertyName("imageDesc")]
        public string? ImageDesc {get; set;}

        [JsonPropertyName("storyDesc")]
        public string? StoryDesc {get; set;}
        
        [JsonPropertyName("userId")]
        public Guid UserId {get; set;}
        
        
    }
}