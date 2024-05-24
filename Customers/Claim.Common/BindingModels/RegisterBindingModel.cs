using System.ComponentModel.DataAnnotations;

namespace Claim.Common.BindingModels;

public class RegisterBindingModel
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Gender { get; set; }= string.Empty;
    [Required]
    public string Phone { get; set; }= string.Empty;
    public string ProfilePic { get; set; }= string.Empty;
}