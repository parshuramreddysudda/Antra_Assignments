using ApplicationCore.Model.Request;
using ApplicationCore.ServiceContracts;
using AutoMapper;
using ApplicationCore.Entities.Product;
using ApplicationCore.RepositoryContracts;

namespace ECommerce.Api.Products.Interfaces
{
    public class ProductServiceAsync : IProductServiceAsync
    {
        private readonly IProductRepositoryAsync _productRepository;
        private readonly IMapper _mapper;
        public ProductServiceAsync(IProductRepositoryAsync productRepository,IMapper mapper)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<(bool IsSuccess, IEnumerable<ProductRequestModel> products, string ErrorMessage)> GetProductsAsync()
        {
            try
            {
                var products = await _productRepository.GetAllAsync();
                if (products != null && products.Any())
                {
                    var result = _mapper.Map<IEnumerable<ProductRequestModel>>(products);
                    return (true, result, null);
                }
                return (false, null, "No products found");
            }
            catch (Exception ex)
            {
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, ProductRequestModel product, string ErrorMessage)> GetProductAsync(int id)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(id);
                if (product != null)
                {
                    var result = _mapper.Map<ProductRequestModel>(product);
                    return (true, result, null);
                }
                return (false, null, "Product not found");
            }
            catch (Exception ex)
            {
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, int id, string ErrorMessage)> InsertProductAsync(ProductRequestModel entity)
        {
            try
            {
                var result = _productRepository.InsertAsync(_mapper.Map<Product>(entity));
                if(result!=null)
                    return (true, 1, null);
                return (false, 0, "Product Insertion Failed");
            }
            catch (Exception ex)
            {
                return (false, 0, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, int id, string ErrorMessage)> UpdateProductAsync(ProductRequestModel entity)
        {
            try
            {
                var product = await _productRepository.UpdateAsync(_mapper.Map<Product>(entity));
                if (product != null)
                {
                    return (true, 1, null);
                }
                return (false, 0, "Product not found");
            }
            catch (Exception ex)
            {
                return (false, 0, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, int id, string ErrorMessage)> DeleteProductAsync(int id)
        {
            try
            {
                var product = await _productRepository.DeleteAsync(id);
                if (product != null)
                {
                    var result = _mapper.Map<ProductRequestModel>(product);
                    return (true, 1, null);
                }
                return (false, 0, "Product not found");
            }
            catch (Exception ex)
            {
                return (false, 0, ex.Message);
            }
        }
    }
}
