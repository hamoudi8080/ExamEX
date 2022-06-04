using Model;

namespace Contract;

public interface IBook
{
 
    Task <ICollection<Book>> getBooks();

    Task <Book> createBook(Book book);
    
    Task deleteBook(int id);
}