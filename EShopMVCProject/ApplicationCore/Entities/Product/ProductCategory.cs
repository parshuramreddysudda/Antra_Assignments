namespace ApplicationCore.Entities.Product;

public class ProductCategory
{
    public int Id { get; set; }
    public String Name { get; set; }= string.Empty;
    public int Parent_category_Id { get; set; }
    public List<CategoryVariation> CategoryVariation { get; set; }
    public List<Product> Products { get; set; }
    
    
    public List<ProductCategory> GetTestData()
    {
        return new List<ProductCategory>
        {
            new ProductCategory { Name = "Electronics", Id = 4 },
            new ProductCategory { Name = "Mobile Phones", Id = 1 },
            new ProductCategory { Name = "Laptops", Id = 1 },
            new ProductCategory { Name = "Clothing", Id = 4 },
            new ProductCategory { Name = "Men's Clothing", Id = 4 },
            new ProductCategory { Name = "Women's Clothing", Id = 4 },
            new ProductCategory { Name = "Books", Id = 3 },
            new ProductCategory { Name = "Fiction", Id = 7 },
            new ProductCategory { Name = "Non-Fiction", Id = 7 },
            new ProductCategory { Name = "Home & Kitchen", Id = 4 },
            new ProductCategory { Name = "Kitchen Appliances", Id = 10 },
            new ProductCategory { Name = "Home Decor", Id = 10 }
        };
    }
}