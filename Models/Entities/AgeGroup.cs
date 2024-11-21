namespace StoryBook.Models
{
    public class AgeGroup
    {
        public int AgeGroupId {get; set;}
        public required string GroupName {get; set;}
        public ICollection<UserGroup>? UserAgeGroups { get; set; } = new List<UserGroup>();
    }
}