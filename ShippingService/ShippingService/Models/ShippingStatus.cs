namespace ShippingService.Models;

public class ShippingStatus
{
    public string Id { get; set; }
    public string CustomerId { get; set; }
    public string OrderId { get; set; }
    public string Status { get; set; }
}
