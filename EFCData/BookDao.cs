using Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model;

namespace EFCData;

public class BookDao :IBook
{
    private readonly AContext context;

    public BookDao(AContext context)
    {
        this.context = context;
    }
    public async Task<ICollection<Book>> getBooks()
    {
        ICollection<Book> collection = await context.Books.ToListAsync();
        
        return collection;
    }

    public async Task <Book> createBook(Book book)
    {
         
        EntityEntry<Book> added = await context.AddAsync(book);
     
        await context.SaveChangesAsync();
        return added.Entity;
    }

    public async Task deleteBook(int id)
    {
        Book? existing = await context.Books.FindAsync(id);
        if (existing is null)
        {
            throw new Exception($"Could not find BOOK with id {id}. Nothing was deleted");
        }

        context.Books.Remove(existing);
        await context.SaveChangesAsync();
    }
}