namespace TechTask.Models.Entities;

public class Location
{
    public int Id { get; set; }
    
    public string Country { get; set; }
    
    public string OfficeName { get; set; }
    
    public string Address { get; set; }
    
    public int PostalCode { get; set; }
    
    public string City { get; set; }
    
    public string State { get; set; }
}