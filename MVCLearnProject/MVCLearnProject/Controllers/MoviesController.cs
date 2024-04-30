using Microsoft.AspNetCore.Mvc;
using MVCLearnProject.Models;
using MVCLearnProject.ViewModel;

namespace MVCLearnProject.Controllers;

public class MoviesController : Controller
{
    // GET
    public IActionResult Random()
    {
        Movie _movie = new Movie()
        {
            Name = "RRR!"
        };
        
        //return View(_movie);
        //return Content("Hello World");
        /*return RedirectToAction("Index", "Home",new
        {
            page =1,
            sortBy = "asd"
        });
        */
        //ViewData["Movie"] = _movie;
        var customers = new List<Customer>
        {
            new Customer { Name = "Ram" },
            new Customer { Name = "Akshay" }
        };

        RandomMovieModel obj = new RandomMovieModel
        {
            Customers = customers,
            Movie = _movie
            
        };
        
        ViewBag.Movie = _movie;


        return View(obj);
    }

    public IActionResult Edit(int Id)
    {
        return Content("ID is " + Id);
    }

    public IActionResult Index(int? pageIndex, string sortby)
    {
        if (pageIndex.HasValue)
            pageIndex = 1;
        return Content("Page Index "+pageIndex);
    }
    
}