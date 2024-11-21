namespace StoryBook.Models
{
   public class UserGroup
{
    public Guid UserGroupId {get; set;}
    public Guid UserId { get; set; }  
    public UserProfile? UserProfile { get; set; }  

    public int AgeGroupId { get; set; }  
    public AgeGroup? AgeGroup { get; set;} 

     public int ThemeId {get; set;}
     public Themes? Theme {get; set;}
   
    
}
}
