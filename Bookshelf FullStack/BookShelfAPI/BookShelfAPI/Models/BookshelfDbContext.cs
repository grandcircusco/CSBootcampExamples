using Microsoft.EntityFrameworkCore;

namespace BookShelfAPI.Models
{
    public class BookshelfDbContext : DbContext
    {
        protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "AuthorDb");
        }
        public DbSet<Book> Books { get; set; }
    }
}
