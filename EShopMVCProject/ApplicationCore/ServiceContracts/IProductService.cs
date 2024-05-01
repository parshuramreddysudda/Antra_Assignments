using ApplicationCore.Model.Response;

namespace ApplicationCore.ServiceContracts;

public interface IProductService
{
    IEnumerable<ProductResponseModel> GetAllProducts();
    int InsertProduct(ProductResponseModel product);
    int UpdateProduct(ProductResponseModel product);
    int DeleteProduct(ProductResponseModel product);
    ProductResponseModel GetProductByID(int id);

} 