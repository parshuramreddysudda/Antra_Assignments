using ApplicationCore.Entities.Product;
using ApplicationCore.Model.Request;
using ApplicationCore.Model.Response;

namespace ApplicationCore.ServiceContracts;

public interface IProductServiceAsync
{
    Task<(bool IsSuccess, IEnumerable<ProductRequestModel> products, string ErrorMessage)> GetProductsAsync();
    Task<(bool IsSuccess, ProductRequestModel product, string ErrorMessage)> GetProductAsync(int id);
    Task<(bool IsSuccess, int id, string ErrorMessage)> InsertProductAsync(ProductRequestModel entity);
    Task<(bool IsSuccess, int id, string ErrorMessage)> UpdateProductAsync(ProductRequestModel entity);
    Task<(bool IsSuccess, int id, string ErrorMessage)> DeleteProductAsync(int id);

} 