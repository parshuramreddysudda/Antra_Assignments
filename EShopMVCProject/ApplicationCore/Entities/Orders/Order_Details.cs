using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities.Orders;

public class Order_Details
{
    [Required]
    public int Id { get; set; }
    [Required]
    public int Order_Id { get; set; }
    public Order Order { get; set; }
    public int ProductID { get; set; }
    [Required]
    public Product.Product ProductId { get; set; }
    public string ProductName { get; set; }
    public int Qty { get; set; }
    public int Price { get; set; }
    public int Discount { get; set; }
}