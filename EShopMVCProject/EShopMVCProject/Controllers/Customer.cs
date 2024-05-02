using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace EShopMVCProject.Controllers;

public class Customer : Controller
{
    // GET
    private readonly CustomerService _customerService;

    public Customer(CustomerService _customerService)
    {
        this._customerService = _customerService;
    }
    
    
    public IActionResult Index()
    {
        var collection = _customerService.GetAllCustomers();
        return View();
    }
}