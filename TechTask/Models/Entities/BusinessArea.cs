namespace TechTask.Models.Entities;

public class BusinessArea
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public ICollection<User> Users { get; set; }
}