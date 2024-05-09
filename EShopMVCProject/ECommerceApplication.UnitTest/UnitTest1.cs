using Infrastructure.Service;

namespace ECommerceApplication.UnitTest;

[TestClass]
public class UnitTest1
{
    private ProductService _sut;
    private CustomerService _customerService;
    
    [TestMethod]
    public void TestOfGetAllproductsReturnsResult()
    {
        //ProductService,cs.cs = > GetAllProductsAsync()
        //System under Test:

        var products = _sut.GetAllProducts();
        var customer = _customerService.GetAllCustomers();

    }
}