using System.ComponentModel.DataAnnotations;

namespace Umbraco_Assignment_CMS.ViewModels;

public class EmailFormViewModel
{

    [Required(ErrorMessage = "Email is required")]
    [Display(Name = "Email address")]
    [RegularExpression(
    @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
    ErrorMessage = "Not a valid email address")]
    public string Email { get; set; } = null!;
}
