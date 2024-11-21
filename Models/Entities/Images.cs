namespace StoryBook.Models
{
    public class Images
    {
        public Guid ImageId {get; set;}
        public required string ImageUrl {get; set;}
        public required string ImageDesc {get; set;}

        public int ThemeId {get; set;}
        public Themes? Theme {get; set;}

       
    }
}