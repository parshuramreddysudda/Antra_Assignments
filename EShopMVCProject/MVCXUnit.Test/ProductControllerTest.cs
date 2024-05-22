using ApplicationCore.Entities.Product;
using ApplicationCore.Model.MockData;
using ApplicationCore.Model.Response;
using ApplicationCore.RepositoryContracts;
using ApplicationCore.ServiceContracts;
using EShopMVCProject.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace MVCXUnit.Test;

public class ProductControllerTest
{
    public ProductControllerTest()
    {
        var mockRepo = new Mock<IProductService>();
        var mockData = new MockData();
        var productCategory = new Mock<IProductCategoryRepository>();
    }
    
    [Fact]
    public void IndexUnitTest()
    {
     
        mockRepo.Setup(x => x.GetAllProducts()).Returns(mockData.GetAllProducts());
        var controller = new ProductController(mockRepo.Object,productCategory.Object);
        
        // Act
        var result = controller.Index();
        
        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        Console.WriteLine(viewResult.ViewData);
        var viewResultBooks = Assert.IsAssignableFrom<IEnumerable<ProductResponseModel>>(viewResult.Model);
        Assert.Equal(mockData.GetAllProducts().Count(),viewResultBooks.Count());
    }
}