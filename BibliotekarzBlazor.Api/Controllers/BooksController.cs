using BibliotekarzBlazor.Api.Services;
using BibliotekarzBlazor.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BibliotekarzBlazor.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService bookService;

    public BooksController(IBookService bookService)
    {
        this.bookService = bookService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(bookService.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        BookDto book = bookService.GetById(id);
        if (book is null)
        {
            return NotFound();
        }
        return Ok(book);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] BookDto book)
    {
        bookService.Add(book);
        return Created($"api/Books/{book.Id}", book);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] BookDto book)
    {
        bookService.Update(book);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        bookService.Delete(id);
        return NoContent();
    }
}