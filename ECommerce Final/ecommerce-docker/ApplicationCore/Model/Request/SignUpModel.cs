using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Model.Request;

public class SignUpModel
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Phone { get; set; }
    [Required]
    [Compare("ConfirmPassword")]
    public string Password { get; set; }
    [Required]
    public string ConfirmPassword { get; set; }
}