using Contract;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace ExamEX.Controllers;


[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{

    private IBook book;
    
    public BookController(IBook book)
    {
        this.book = book;
    }
    
    
    [HttpGet]
    public async Task<ActionResult<Book>> GetList()
    {
  
        try
        {
            ICollection<Book> todos = await book.getBooks();

            return Ok(todos);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult> DeleteTodoById([FromRoute] int id)
    {
        try
        {
            await book.deleteBook(id);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        } 
    }
    
    
    [HttpPost]
    [Route("{id:int}")]
    public async Task<ActionResult<Book>> AddBook([FromBody] Book addBook, int id)
    {
        try
        {
            addBook.id = id;
            Book added = await book.createBook(addBook);
           
            return Created($"/book/{added.ISBN}", added);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }


    
}