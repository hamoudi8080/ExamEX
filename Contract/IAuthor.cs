using Model;

namespace Contract;

public interface IAuthor
{
    Task <Author> createAuthor(Author author);
    Task <ICollection<Author>> getList();
}