using System.ComponentModel.DataAnnotations;

namespace ShippingService.Entity;

public class ShippingStatus
{
    [Required]
    public string Id { get; set; }
    [Required]
    public string CustomerId { get; set; }
    [Required]
    public string OrderId { get; set; }
    public string Status { get; set; }
}
