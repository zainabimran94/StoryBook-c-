namespace StoryBook.Models
{
     public class GetStoryDto
    {
        public Guid PythonDataId { get; set; }  
        public Guid UserId {get; set;}
        public required string StoryGenTitle {get; set;}
        public required string StoryBook {get; set;}
        public required string StoryImageUrl {get; set;}

        
    }
}