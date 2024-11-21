namespace StoryBook.Models
{
    public class UserProfile
    {
        public Guid UserId {get; set;}
        public required string Email {get; set;}
        public required string Name { get; set; }
        public string ? PasswordHash { get; set; }
        public string? ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set;}
        public ICollection<UserGroup>? UserGroups { get; set; }
        public ICollection<PythonData>? PythonData {get; set;}
        public ICollection<UserPreference>? UserPreferences { get; set; }  
       
       
    }
}