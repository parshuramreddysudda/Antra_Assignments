using ApplicationCore.Entities.Product;
using ApplicationCore.Model.Request;
using ApplicationCore.Model.Response;
using ApplicationCore.RepositoryContracts;
using ApplicationCore.ServiceContracts;
using Infrastructure.Repository;

namespace Infrastructure.Service;

public class ProductService:IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IProductCategoryRepository _productCategoryRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public IEnumerable<ProductResponseModel> GetAllProducts()
    {
        List<ProductResponseModel> productList = new List<ProductResponseModel>();

        // Retrieve all products
        var products = _productRepository.GetAll();

        // Iterate over each product to create ProductResponseModel
        foreach (var product in products)
        {
            ProductResponseModel productResponseModel = new ProductResponseModel
            {
                ID = product.ID,
                Name = product.Name,
                Description = product.Description,
                CategoryId = product.CategoryId,
                Price = product.Price,
                Qty = product.Qty,
                Product_image = product.Product_image
            };

            productList.Add(productResponseModel);
        }

        return productList;
    }


    public int InsertProduct(ProductRequestModel product)
    {
        Product updatedProduct = new Product()
        {
            ID = product.ID,
            Name = product.Name,
            Description = product.Description,
            CategoryId = product.CategoryId,
            Price = product.Price,
            Qty = product.Qty,
            Product_image = product.Product_image
        };
        return _productRepository.Insert(updatedProduct);
    }

    public int UpdateProduct(ProductRequestModel product)
    {
        Product updatedProduct = new Product()
        {
            ID = product.ID,
            Name = product.Name,
            Description = product.Description,
            CategoryId = product.CategoryId,
            Price = product.Price,
            Qty = product.Qty,
            Product_image = product.Product_image
        };
        return _productRepository.Update(updatedProduct);
    }

    public int DeleteProduct(int id)
    {
        return _productRepository.Delete(id);
    }

    public ProductResponseModel GetProductByID(int id)
    {
        
        var product = _productRepository.GetById(id);
        if (product != null)
        {
            ProductResponseModel productResponseModel = new ProductResponseModel();
            productResponseModel.Name = product.Name;
            productResponseModel.ID = product.ID;
            productResponseModel.Description = product.Description;
            return productResponseModel;
        }

        return null;
    }
}