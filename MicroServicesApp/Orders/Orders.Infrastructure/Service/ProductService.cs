using ApplicationCore.Entities.Product;
using ApplicationCore.Model.Request;
using ApplicationCore.Model.Response;
using ApplicationCore.RepositoryContracts;
using ApplicationCore.ServiceContracts;
using Infrastructure.Repository;

namespace Infrastructure.Service;

public class ProductServiceAsync:IProductServiceAsync
{
    private readonly IProductRepositoryAsync _productRepository;
    private readonly IProductCategoryRepositoryAsync _productCategoryRepository;

    public ProductServiceAsync(IProductRepositoryAsync productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<IEnumerable<ProductResponseModel>> GetAllProductsAsync()
    {
        List<ProductResponseModel> productList = new List<ProductResponseModel>();

        // Retrieve all products
        var products = await _productRepository.GetAllAsync();

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


    public async Task<int> InsertProductAsync(ProductRequestModel product)
    {
        ApplicationCore.Entities.Product.Product updatedProduct = new ApplicationCore.Entities.Product.Product()
        {
            ID = product.ID,
            Name = product.Name,
            Description = product.Description,
            CategoryId = product.CategoryId,
            Price = product.Price,
            Qty = product.Qty,
            Product_image = product.Product_image
        };
        return await _productRepository.InsertAsync(updatedProduct);
    }

    public async Task<int> UpdateProductAsync(ProductRequestModel product)
    {
        ApplicationCore.Entities.Product.Product updatedProduct = new ApplicationCore.Entities.Product.Product()
        {
            ID = product.ID,
            Name = product.Name,
            Description = product.Description,
            CategoryId = product.CategoryId,
            Price = product.Price,
            Qty = product.Qty,
            Product_image = product.Product_image
        };
        return await _productRepository.UpdateAsync(updatedProduct);
    }

    public async Task<int> DeleteProductAsync(int id)
    {
        return await _productRepository.DeleteAsync(id);
    }

    public async Task<ProductResponseModel> GetProductByIDAsync(int id)
    {
        
        var product = await _productRepository.GetByIdAsync(id);
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