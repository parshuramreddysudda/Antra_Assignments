using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities.Orders;

public class Order
{
    [Required]
    public int Id { get; set; }
    public DateOnly Order_date { get; set; }
    [Required]
    public int CustomerId { get; set; }
    public Customer.Customer Customer { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public int PaymentMethodId { get; set; }
    public string PaymentName { get; set; }=string.Empty;
    public string ShippingAddress { get; set; }=string.Empty;
    public string ShippingMethod { get; set; }=string.Empty;
    public int BillAmount { get; set; }
    public string OrderStatus { get; set; }=string.Empty;
    
}