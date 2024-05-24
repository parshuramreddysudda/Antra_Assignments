using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;

namespace ApplicationCore.Entities.ApplicationUser;

public class ApplicationUser:IdentityUser<int>
{
    [Required]
    public int CustomerId { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    public DateTime DateCreated { get; set; }
    [Required]
    public string Gender { get; set; }= string.Empty;
    [Required]
    public string Phone { get; set; }= string.Empty;
    public string ProfilePic { get; set; }= string.Empty;
    public string UserId { get; set; } 

}
