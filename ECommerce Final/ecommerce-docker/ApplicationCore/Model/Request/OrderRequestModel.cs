namespace ApplicationCore.Model.Request;

public class OrderRequestModel
{
    public int Id { get; set; }
    public DateOnly DateOnly { get; set; }
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    public string PaymentMethod { get; set; }
    public string PaymentName { get; set; }
    public string ShippingMethod { get; set; }
    public string ShippingAddress { get; set; }
    public decimal BillAmount { get; set; }
    public string OrderStatus { get; set; }
}