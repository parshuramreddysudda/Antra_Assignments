
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities.Orders;

public class OrderDetails
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int? Order_Id { get; set; }
    public Order Order { get; set; }
    [Required]
    public int ProductId { get; set; }
    public Product.Product Product { get; set; }
    [Required]
    public int ProductPrice { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
}