using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Umbraco_Assignment_CMS.ViewModels;

public class CallbackFormViewModel
{
    [Required(ErrorMessage = "Name is Required")]
    [Display(Name = "Name")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Email is required")]
    [Display(Name = "Email address")]
    [RegularExpression(
    @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
    ErrorMessage = "Not a valid email address")]
    public string Email { get; set; } = null!;


    [Required(ErrorMessage = "Phone is Required")]
    [Display(Name = "Phone")]
    public string Phone { get; set; } = null!;

    [Required(ErrorMessage = "An Option is Required")]
    [Display(Name = "Options")]

    public string SelectedOption { get; set; } = null!;

    [ValidateNever]
    public IEnumerable<string> Options { get; set; } = null!;

}
