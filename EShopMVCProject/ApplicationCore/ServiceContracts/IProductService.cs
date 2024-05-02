using ApplicationCore.Model.Request;
using ApplicationCore.Model.Response;

namespace ApplicationCore.ServiceContracts;

public interface IProductService
{
    IEnumerable<ProductResponseModel> GetAllProducts();
    int InsertProduct(ProductRequestModel product);
    int UpdateProduct(ProductRequestModel product);
    int DeleteProduct(int Id);
    ProductResponseModel GetProductByID(int id);

} 