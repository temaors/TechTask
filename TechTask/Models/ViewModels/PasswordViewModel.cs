using System.ComponentModel.DataAnnotations;

namespace TechTask.Models;

[Serializable]
public class PasswordViewModel
{
    [Required (ErrorMessage = "!")]
    public string Pass { get; set; }
    [Required (ErrorMessage = "!")]
    public string ConfirmPass { get; set; }
    [Required (ErrorMessage = "!")]
    public bool IsTermsAccepted { get; set; }
}