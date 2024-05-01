using ApplicationCore.Entities.Product;
using ApplicationCore.Model.Response;
using ApplicationCore.RepositoryContracts;
using ApplicationCore.ServiceContracts;

namespace Infrastructure.Service;

public class ProductService:IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepo)
    {
        _productRepository = productRepo;
    }
    public IEnumerable<ProductResponseModel> GetAllProducts()
    {
        List<ProductResponseModel> list = new List<ProductResponseModel>();
        var collection = _productRepository.GetAll();
        if (collection != null)
        {
            foreach (var product in collection)
            {
                ProductResponseModel productResponseModel = new ProductResponseModel();
                productResponseModel.Name = product.Name;
                productResponseModel.ID = product.ID;
                productResponseModel.Description = product.Description;
            }
        }
        
    }

    public int InsertProduct(ProductResponseModel product)
    {
        Product updatedProduct = new Product()
        {
            Name = product.Name,
            ID = product.ID,
            Description = product.Description
        };
        return _productRepository.Insert(updatedProduct);
    }

    public int UpdateProduct(ProductResponseModel product)
    {
        Product updatedProduct = new Product()
        {
            Name = product.Name,
            ID = product.ID,
            Description = product.Description
        };
        return _productRepository.Update(updatedProduct);
    }

    public int DeleteProduct(ProductResponseModel product)
    {
        throw new NotImplementedException();
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
        }

        return null;
    }
}