using System.ComponentModel.DataAnnotations;
using TechTask.Validators;

namespace TechTask.Models.Entities;

public class User
{
    public int Id { get; set; }

    public ContactInfo ContactInfo{ get; set; }
    
    public Location Location { get; set; }
    
    public string Password { get; set; }
    
    public ICollection<BusinessArea> BusinessAreas { get; set; }
}