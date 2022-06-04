using Contract;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace ExamEX.Controllers;

[ApiController]
[Route("[controller]")]


public class AuthorController : ControllerBase
{
    private IAuthor iauthor;

    public AuthorController(IAuthor iauthor)
    {
        this.iauthor = iauthor;
    }
    
    
    [HttpGet]
    public async Task<ActionResult<Author>> GetList()
    {
  
        try
        {
            ICollection<Author> todos = await iauthor.getList();

            return Ok(todos);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    
    [HttpPost]
    public async Task<ActionResult<Author>> createPost( [FromBody]  Author author )
    {
        try
        {
            await iauthor.createAuthor(author);
            return Ok();

        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}