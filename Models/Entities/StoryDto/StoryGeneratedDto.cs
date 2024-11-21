using System.Text.Json.Serialization;

namespace StoryBook.Models
{
    public class StoryGeneratedDto
    {
        [JsonPropertyName("storyGenTitle")]
        public string? StoryGenTitle {get; set;}
        [JsonPropertyName("storyBook")] 
        public string? StoryBook {get; set;}
        
        [JsonPropertyName("storyImageUrl")] 
        public string? StoryImageUrl {get; set;}

        [JsonPropertyName("userId")]
        public Guid UserId {get; set;}

    }
}