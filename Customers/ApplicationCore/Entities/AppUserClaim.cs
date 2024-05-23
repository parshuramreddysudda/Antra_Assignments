namespace ApplicationCore.Entities;

public class AppUserClaim
{
    public int Id { get; set; }
    public string ClaimType { get; set; }
    public string ClaimValue  { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }
    
    
}