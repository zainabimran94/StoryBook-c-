namespace StoryBook.Models
{
    public class Themes
    {
        public int ThemeId {get; set;}
        public required string ThemeName {get; set;}
        public required string ThemeDesc {get; set;}

         public ICollection<UserGroup>? UserThemeGroups { get; set; } = new List<UserGroup>();
         public ICollection<Images>? Images { get; set; } = new List<Images>();
    }
}