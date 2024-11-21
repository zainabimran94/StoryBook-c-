namespace StoryBook.Models
{
    public class UserPreference 
    {
        public Guid UserPreferenceId {get; set;}
        public Guid UserId { get; set; }  
        public UserProfile? UserProfile { get; set; }  
        public required string ThemeName {get; set;}
        public required string GroupName {get; set;}
        public string? ImageDesc {get; set;}
        public string? StoryDesc {get; set;}

    }
}