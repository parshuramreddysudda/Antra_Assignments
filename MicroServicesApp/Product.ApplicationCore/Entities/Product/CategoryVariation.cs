namespace ApplicationCore.Entities.Product;

public class CategoryVariation
{
    public int Id { get; set; }
    public int Category_Id { get; set; }
    public string Variation_Name { get; set; }= string.Empty;
    public List<ProductCategory> ProductCategories { get; set; }
}