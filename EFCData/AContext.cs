using Microsoft.EntityFrameworkCore;
using Model;

namespace EFCData;

public class AContext : DbContext
{
    public DbSet<Author> Author { get; set; }
    public DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source = C:\DNP\ExamEX\EFCData\Author.db");
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>()
            .HasMany(t => t.BooksAuthored)
            .WithOne(p => p.author)
            .HasForeignKey(p => p.id)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        //modelBuilder.Entity<Author>().HasKey(a => a.id);
    }
    
    
 
}
//AFTER download the packages from tools -> NuGet -> NuGet windows tool
//all version 6.0.3
//Microsoft.EntityFrameworkCore
// Microsoft.EntityFrameworkCore.Design
// Microsoft.EntityFrameworkCore.Sqlite 

//Internal Dependency EFData -> Domain  this is so EfcData can use the  interface, and the model class.
//web api -> EFData EfcData. This is so WebAPI can register services from EfcData,
//and thereby use the database.

//in terminal type-> dotnet tool install -g dotnet-ef
// This will install the db tools. The -g means it is a global installation,
// so all future solutions should also have this tool installed.