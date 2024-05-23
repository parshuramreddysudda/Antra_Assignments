using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities.Product;
public class Product
{
    [Required]
    public int ID { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    [Required]
    [MaxLength(2000)]
    public string Description { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    [ForeignKey("CategoryId")]
    public ProductCategory Category { get; set; }
    public int Price { get; set; }
    public int Qty { get; set; }
    public string Product_image { get; set; } = string.Empty;
    public string SKU { get; set; } = string.Empty;
}