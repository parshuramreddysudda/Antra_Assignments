namespace ApplicationCore.Entities.Product;

public class CategoryVariation
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string VariationName { get; set; } = string.Empty;
    public ICollection<ProductCategory> ProductCategories { get; set; }
}