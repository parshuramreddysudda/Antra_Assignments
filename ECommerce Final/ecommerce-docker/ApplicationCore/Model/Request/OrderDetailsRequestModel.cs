namespace ApplicationCore.Model.Request;

public class OrderDetailsRequestModel
{
    public int Id { get; set; }
    public OrderRequestModel OrderRequestModelId { get; set; }
    public int ProductId { get; set; }
    public int ProductPrice { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
}