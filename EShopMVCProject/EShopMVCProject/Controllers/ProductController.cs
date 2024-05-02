using ApplicationCore.Entities.Product;
using ApplicationCore.Model.Request;
using ApplicationCore.Model.Response;
using ApplicationCore.RepositoryContracts;
using ApplicationCore.ServiceContracts;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EShopMVCProject.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;
    private readonly IProductCategoryRepository _productCategory;

    public ProductController(IProductService _productService,IProductCategoryRepository _productCategory)
    {
        this._productService = _productService;
        this._productCategory = _productCategory;
    }
    // GET
    public IActionResult Index()
    {
        var collection = _productService.GetAllProducts();
        return View(collection);
    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Categories  = _productCategory.GetAll();
        return View();
    }

    [HttpPost]
    public IActionResult Create(ProductRequestModel model)
    {
        if (ModelState.IsValid)
        {
            _productService.InsertProduct(model);
            return RedirectToAction("Index");
        }
        Console.WriteLine("Error Inserting the Product"+ModelState);
        return View(model);
    }

    public IActionResult Delete(int id)
    {
        var product = _productService.GetProductByID(id);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }
    [HttpPost]
    public IActionResult Delete(ProductResponseModel productResponseModel)
    {
       _productService.DeleteProduct(productResponseModel.ID);
        return RedirectToAction("Index");
    }

    public IActionResult Update(int id)
    {
        var product = _productService.GetProductByID(id);
        ViewBag.Categories  = _productCategory.GetAll();
        return View(product);
    }

    [HttpPost]
    public IActionResult Update(ProductResponseModel model)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                Console.WriteLine(error.ErrorMessage);
            }
        }

        if (ModelState.IsValid)
        {
            var productRequest = new ProductRequestModel
            {
                ID = model.ID,
                Name = model.Name,
                Description = model.Description,
                CategoryId = model.CategoryId,
                Price = model.Price,
                Qty = model.Qty,
                Product_image = model.Product_image
            };
            _productService.UpdateProduct(productRequest);
            return RedirectToAction("Index");
        }
        return View(model);
    }
}