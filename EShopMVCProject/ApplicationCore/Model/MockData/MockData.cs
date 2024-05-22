using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationCore.Model.Request;
using ApplicationCore.Model.Response;
using ApplicationCore.ServiceContracts;

namespace ApplicationCore.Model.MockData
{
    public class MockData : IProductService
    {
        private readonly List<ProductResponseModel> _products;

        public MockData()
        {
            // Initialize with some mock data
            _products = new List<ProductResponseModel>
            {
                new ProductResponseModel
                {
                    ID = 1,
                    Name = "Sample Product 1",
                    Description = "This is a sample product description 1.",
                    CategoryId = 10,
                    Price = 100,
                    Qty = 50,
                    Product_image = "sample_image_1.jpg",
                    SKU = "SP1001"
                },
                new ProductResponseModel
                {
                    ID = 2,
                    Name = "Sample Product 2",
                    Description = "This is a sample product description 2.",
                    CategoryId = 20,
                    Price = 200,
                    Qty = 30,
                    Product_image = "sample_image_2.jpg",
                    SKU = "SP2002"
                }
            };
        }

        public IEnumerable<ProductResponseModel> GetAllProducts()
        {
            return _products;
        }

        public int InsertProduct(ProductRequestModel product)
        {
            var newProduct = new ProductResponseModel
            {
                ID = _products.Max(p => p.ID) + 1,
                Name = product.Name,
                Description = product.Description,
                CategoryId = product.CategoryId,
                Price = product.Price,
                Qty = product.Qty,
                Product_image = product.Product_image,
                SKU = product.SKU
            };

            _products.Add(newProduct);
            return newProduct.ID;
        }

        public int UpdateProduct(ProductRequestModel product)
        {
            var existingProduct = _products.FirstOrDefault(p => p.ID == product.ID);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.CategoryId = product.CategoryId;
                existingProduct.Price = product.Price;
                existingProduct.Qty = product.Qty;
                existingProduct.Product_image = product.Product_image;
                existingProduct.SKU = product.SKU;
                return existingProduct.ID;
            }
            return 0; // Return 0 if the product to update was not found
        }

        public int DeleteProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.ID == id);
            if (product != null)
            {
                _products.Remove(product);
                return id;
            }
            return 0; // Return 0 if the product to delete was not found
        }

        public ProductResponseModel GetProductByID(int id)
        {
            return _products.FirstOrDefault(p => p.ID == id);
        }
    }
}
