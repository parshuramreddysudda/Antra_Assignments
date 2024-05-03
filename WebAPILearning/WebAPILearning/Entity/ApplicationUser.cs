using Microsoft.AspNetCore.Identity;

namespace WebAPILearning.Entity;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}