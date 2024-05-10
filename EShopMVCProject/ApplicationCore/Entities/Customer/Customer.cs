using System.ComponentModel.DataAnnotations;
using ApplicationCore.Entities.Orders;

namespace ApplicationCore.Entities.Customer;

public class Customer
{
    [Required]
    public int CustomerId { get; set; }
    [Required]
    public string FirstName { get; set; }= string.Empty;
    public string LastName { get; set; }= string.Empty;
    [Required]
    public string Gender { get; set; }= string.Empty;
    [Required]
    public string Phone { get; set; }= string.Empty;
    public string ProfilePic { get; set; }= string.Empty;
    public int UserId { get; set; } 
    public ICollection<Order> Orders { get; set; }
}