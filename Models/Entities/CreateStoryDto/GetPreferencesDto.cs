namespace StoryBook.Models.Dto
{
    public class GetPreferencesDto
    {
        public Guid UserId {get; set;}
        public Guid UserGroupId {get; set;}

        public int ThemeId {get; set;}
        public int AgeId {get; set;}
        public required string GroupName {get; set;}
        public required string ThemeName { get; set; }
       public required List<ImageDto> Images { get; set; }
    }

    public class ImageDto
    { 
       public required string Images {get; set;}
       public required string ImagesDesc {get; set;}
    }
}