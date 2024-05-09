namespace ApplicationCore.Model.Response;

public class ProductResponseModel
{
    public int ID { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; }= string.Empty;
    public int CategoryId { get; set; }
    public int Price { get; set; }
    public int Qty { get; set; }
    public string Product_image { get; set; } = string.Empty;
    public string SKU { get; set; }
}