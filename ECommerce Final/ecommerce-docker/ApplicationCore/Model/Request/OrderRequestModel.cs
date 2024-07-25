
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Model.Request;

public class OrderRequestModel
{
    [Required]
    public int CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
    public string CustomerName { get; set; }
    public string PaymentMethod { get; set; }
    public string PaymentName { get; set; }
    public string ShippingMethod { get; set; }
    public string ShippingAddress { get; set; }
    public decimal BillAmount { get; set; }
    public string OrderStatus { get; set; }
    public List<OrderDetailsRequest> OrderDetails { get; set; }
}

public class OrderDetailsRequest
{
    [Required]
    public int ProductId { get; set; }
    public decimal ProductPrice { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
}

