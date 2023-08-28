using System.ComponentModel.DataAnnotations;

namespace TechTask.Models;

[Serializable]
public class ContactInfoViewModel
{
    [Required (ErrorMessage = "!")]
    public string? Salutation { get; set; }
    [Required (ErrorMessage = "!")]
    [StringLength(50)]
    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    [Required (ErrorMessage = "!")]
    [StringLength(50)]
    public string? LastName { get; set; }
    [Required (ErrorMessage = "!")]
    [StringLength(50)]
    public string? Company { get; set; }
    [Required (ErrorMessage = "!")]
    [StringLength(50)]
    public string? Title { get; set; }
    [Required (ErrorMessage = "!")]
    public string? Email { get; set; }
    
    [Required (ErrorMessage = "!")]
    [Compare(nameof(Email), ErrorMessage = "!")]
    public string? EmailConfirmation { get; set; }
    
    [Required (ErrorMessage = "!")]
    public string? Phone { get; set; }
    
    public string? Fax { get; set; }
    
    public string? Mobile { get; set; }
}