using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities.Orders;

public class Order
{
    [Key]
    public int Id { get; set; }
    public DateOnly OrderDate { get; set; }
    [Required]
    public int CustomerId { get; set; }
    public Customer.Customer Customer { get; set; }
    public string CustomerName { get; set; }
    public string PaymentMethod { get; set; }
    public string PaymentName { get; set; }
    public string ShippingMethod { get; set; }
    public string ShippingAddress { get; set; }
    public decimal BillAmount { get; set; }
    public string OrderStatus { get; set; }
    public List<OrderDetails> OrderDetails { get; set; }
}