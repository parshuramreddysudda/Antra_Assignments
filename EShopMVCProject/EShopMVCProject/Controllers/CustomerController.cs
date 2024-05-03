using ApplicationCore.Model.Request;
using ApplicationCore.Model.Response;
using ApplicationCore.ServiceContracts;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EShopMVCProject.Controllers;

public class CustomerController : Controller
{
    // GET
    private readonly ICustomerService _customerService;

    public List<SelectListItem> GenderList { get; } = new List<SelectListItem>
    {
        new SelectListItem { Value = "Male", Text = "Male" },
        new SelectListItem { Value = "Female", Text = "Female" },
        new SelectListItem { Value = "Other", Text = "Other" }
    };

    public CustomerController(ICustomerService _customerService)
    {
        this._customerService = _customerService;
    }
    
    public IActionResult Index()
    {
        var collection = _customerService.GetAllCustomers();
        return View(collection);
    }
    
    public IActionResult Create()
    {
        ViewBag.Gender = GenderList;
        var model = new CustomerRequestModel();
        return View(model);
    }
    
    [HttpPost]
    public IActionResult Create(CustomerRequestModel responseModel)
    {
        if (ModelState.IsValid)
        {
            _customerService.InsertCustomer(responseModel);
            return RedirectToAction("Index");
        }
        return View();
    }

    public IActionResult Update(int id)
    {
        var customer = _customerService.GetCustomerByID(id);
        ViewBag.Gender = GenderList;
        return View(customer);
    }
    
    [HttpPost]
    public IActionResult Update(CustomerResponseModel customerResponseModel)
    {
        if (ModelState.IsValid)
        {
            // Map properties from CustomerResponseModel to CustomerRequestModel
            CustomerRequestModel customerRequestModel = new CustomerRequestModel
            {
                CustomerId = customerResponseModel.CustomerId,
                FirstName = customerResponseModel.FirstName,
                LastName = customerResponseModel.LastName,
                Gender = customerResponseModel.Gender,
                Phone = customerResponseModel.Phone,
                ProfilePic = customerResponseModel.ProfilePic,
                UserId = customerResponseModel.UserId
            };

            // Call the update method with the mapped CustomerRequestModel
            _customerService.UpdateCustomer(customerRequestModel);

            return RedirectToAction("Index");
        }
        return View(customerResponseModel);
    }
    
    public IActionResult Delete(int id)
    {
        var customer = _customerService.GetCustomerByID(id);
        if (customer == null)
        {
            return NotFound();
        }

        return View(customer);
    }
    [HttpPost]
    public IActionResult Delete(ProductResponseModel productResponseModel)
    {
        _customerService.DeleteCustomer(productResponseModel.ID);
        return RedirectToAction("Index");
    }
}