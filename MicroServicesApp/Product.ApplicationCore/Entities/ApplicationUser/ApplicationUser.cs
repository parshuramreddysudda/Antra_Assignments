using Microsoft.AspNetCore.Identity;

namespace ApplicationCore.Entities.ApplicationUser;

public class ApplicationUser:IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
}
