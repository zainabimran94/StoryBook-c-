namespace StoryBook.Models.AuthDto
{
    public class RegisterDto
    {
        public required string Email { get; set; }
        public required string Name { get; set; }
        public required string Password { get; set; }
    }
}
