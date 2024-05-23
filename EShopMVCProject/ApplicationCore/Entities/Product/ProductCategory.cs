using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationCore.Entities.Product;

public class ProductCategory
{
    public int Id { get; set; }
    [Required]
    [MaxLength(30)]
    public string Name { get; set; } = string.Empty;
    public int ParentCategoryId { get; set; }
    [ForeignKey("ParentCategoryId")]
    public CategoryVariation CategoryVariation { get; set; }
    public ICollection<Product> Products { get; set; }
}