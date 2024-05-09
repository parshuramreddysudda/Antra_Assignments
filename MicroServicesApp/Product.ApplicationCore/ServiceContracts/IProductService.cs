using ApplicationCore.Model.Request;
using ApplicationCore.Model.Response;

namespace ApplicationCore.ServiceContracts;

public interface IProductServiceAsync
{
    Task<IEnumerable<ProductResponseModel>> GetAllProductsAsync();
    Task<int> InsertProductAsync(ProductRequestModel product);
    Task<int> UpdateProductAsync(ProductRequestModel product);
    Task<int> DeleteProductAsync(int Id);
    Task<ProductResponseModel> GetProductByIDAsync(int id);

} 