namespace ApplicationCore.Entities.Product;

public class ProductCategory
{
    public int Id { get; set; }
    public String Name { get; set; }= string.Empty;
    public int Parent_category_Id { get; set; }
    public CategoryVariation CategoryVariation { get; set; }
    public List<Product> Products { get; set; }
}