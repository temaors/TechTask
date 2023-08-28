

namespace TechTask.Models.Entities;

[Serializable]
public class ContactInfo
{
    public int Id { get; set; }
    
    public string Salutation { get; set; }
    
    public string FirstName { get; set; }
    
    public string? MiddleName { get; set; }
    
    public string LastName { get; set; }
    
    public string Company { get; set; }
    
    public string Title { get; set; }
    
    public string Email { get; set; }

    public string Phone { get; set; }
    
    public string? Fax { get; set; }
    
    public string? Mobile { get; set; }
}