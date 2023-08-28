using System.ComponentModel.DataAnnotations;

namespace TechTask.Models.ViewModels;

public class BusinessAreaViewModel
{
    public class Area
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }
    [Required]
    public List<Area> Areas { get; set; }
    [Required (ErrorMessage = "!")]
    [StringLength(50)]
    public string Comments { get; set; }
}