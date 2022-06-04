using Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model;

namespace EFCData;

public class AuthorDao :IAuthor
{
    private readonly AContext context;

    public AuthorDao(AContext context)
    {
        this.context = context;
    }
    
    public async Task<Author> createAuthor(Author author)
    {
        EntityEntry<Author> entityAdded = await context.AddAsync(author);
        await context.SaveChangesAsync();
        return entityAdded.Entity;
    } 

    public async Task<ICollection<Author>> getList()
    {
        // var result = context.Author.Include(author => author.BooksAuthored).Select(author => new
        // {
        //     Author = author.id
        // }).ToList();
        
        // ICollection<Author> collection = await context.Author.Where(author => author.FirstName.Equals("sds")).ToListAsync();
        ICollection<Author> collection =  context.Author.Include(author => author.BooksAuthored).ToList(); //returns list of authors 
        

        return collection;
      
    }
}