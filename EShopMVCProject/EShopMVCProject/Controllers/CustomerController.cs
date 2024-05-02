using ApplicationCore.ServiceContracts;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace EShopMVCProject.Controllers;

public class CustomerController : Controller
{
    // GET
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService _customerService)
    {
        this._customerService = _customerService;
    }
    
    public IActionResult Index()
    {
        var collection = _customerService.GetAllCustomers();
        return View(collection);
    }

    public IActionResult Update(int id)
    {
        return View();
    }

    public IActionResult Delete(int id)
    {
        return View();
    }
}