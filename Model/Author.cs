using System.ComponentModel.DataAnnotations;

namespace Model;

public class Author
{
      
    [Key]
    public int id { get; set; }
    [Required, MaxLength(15)]
    public string FirstName { get; set; }
    [Required, MaxLength(15)]
    public string LastName { get; set; }
    
    
    public ICollection<Book> BooksAuthored { get; set; }
    
  
    //
    // public Author(int id, string firstName, string lastName )
    // {
    //     this.id = id;
    //     FirstName = firstName;
    //     LastName = lastName;
    //     
    // }
}