namespace ApplicationCore.Model.Request;

public class OrderResponseModel
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    public string PaymentMethod { get; set; }
    public string PaymentName { get; set; }
    public string ShippingMethod { get; set; }
    public string ShippingAddress { get; set; }
    public decimal BillAmount { get; set; }
    public string OrderStatus { get; set; }
    public List<OrderDetailsResponse> OrderDetails { get; set; }
}

public class OrderDetailsResponse
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public ProductResponse Product { get; set; }
    public decimal ProductPrice { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
}

public class ProductResponse
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Product_image { get; set; }
}
