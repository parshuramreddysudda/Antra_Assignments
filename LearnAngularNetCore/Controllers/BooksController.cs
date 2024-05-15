using LearnAngularNetCore.Data;
using Microsoft.AspNetCore.Mvc;

namespace LearnAngularNetCore.Controllers;

[Route("/api/[controller]")]
class BooksController:ControllerBase
{
    private IBookService _bookService;
    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpPost("AddBook")]
    public IActionResult AddBook([FromBody] Book book){
        _bookService.AddBook(book);
        return Ok("Added");
    }

    [HttpGet("action")]
    public IActionResult GetBooks(int id){
        var allBooks=_bookService.GetAllBooks();
        return Ok(allBooks);
    }
    

}