using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BookService.Models;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private static List<Book> books = new List<Book>();
    private readonly ILogger<BookController> _logger;

    public BookController(ILogger<BookController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public ActionResult<Book> CreateBook([FromBody] Book book)
    {
        if (book == null)
        {
            return BadRequest();
        }

        int newId = books.Count + 1; 
        var newBook = new Book(newId, book.Title, book.Author);
        books.Add(newBook);
        return CreatedAtAction(nameof(GetBookById), new { id = newBook.Id }, newBook);
    }

    [HttpGet("{id}")]
    public ActionResult<Book> GetBookById(int id)
    {
        var book = books.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            return NotFound();
        }
        return book;
    }

    [HttpGet("GetBooks")]
    public IActionResult GetBooks()
    {
        _logger.LogInformation("GET /api/book/GetBooks was called.");
        try
        {
            // Dummy book creation logic to simulate adding a book
            Book book = new Book(0, "1", "1");
            int newId = books.Count + 1;
            var newBook = new Book(newId, book.Title, book.Author);
            books.Add(newBook);
            _logger.LogInformation("Books retrieved successfully.");
            return Ok(books);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error occurred: " + ex.Message);
            return StatusCode(500, "Internal server error: " + ex.Message);
        }
    }
}
