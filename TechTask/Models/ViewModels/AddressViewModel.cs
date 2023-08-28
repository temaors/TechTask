using System.ComponentModel.DataAnnotations;

namespace TechTask.Models.Entities;

[Serializable]
public class AddressViewModel
{
    [Required (ErrorMessage = "!")]
    [StringLength(50)]
    public string Country { get; set; }
    [Required (ErrorMessage = "!")]
    [StringLength(50)]
    public string OfficeName { get; set; }
    [Required (ErrorMessage = "!")]
    [StringLength(250)]
    public string Location { get; set; }
    [Required (ErrorMessage = "!")]
    [Range(0, Int32.MaxValue)]
    public string PostalCode { get; set; }
    [Required (ErrorMessage = "!")]
    [StringLength(50)]
    public string City { get; set; }
    [Required (ErrorMessage = "!")]
    [StringLength(50)]
    public string State { get; set; }
}