using StoryBook.Models;

namespace StoryBook.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(ApplicationUser user, UserProfile userProfile);
       
    }
}
