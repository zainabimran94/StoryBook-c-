using Microsoft.AspNetCore.Identity;

namespace StoryBook.Models
{
    public partial class ApplicationUser : IdentityUser 
    {
        public required string FullName { get; set; } 
        public UserProfile? UserProfile { get; set;}
    }
}