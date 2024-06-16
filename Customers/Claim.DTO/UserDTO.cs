using System.ComponentModel.DataAnnotations;

namespace Claim.DTO;

public class UserDTO
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public string UserId { get; set; } 
    public string Token { get; set; }
    public string Gender { get; set; }= string.Empty;
    public string Phone { get; set; }= string.Empty;
    public string ProfilePic { get; set; }= string.Empty;
    public List<UserClaimDTO> Claims { get; set; }
    
    
    
}