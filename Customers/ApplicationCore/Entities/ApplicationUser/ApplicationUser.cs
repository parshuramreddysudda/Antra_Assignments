using Microsoft.AspNetCore.Identity;

namespace ApplicationCore.Entities.ApplicationUser;

public class ApplicationUser:IdentityUser<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateCreated { get; set; }

}
