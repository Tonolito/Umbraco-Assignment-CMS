using System.ComponentModel.DataAnnotations;

namespace Umbraco_Assignment_CMS.Models;

public class EmailConfirmRequest
{
    [Required]
    public string Email { get; set; } = null!;
}
