namespace BookShelfAPI.Models
{
    public interface IBookRepository
    {
        //WE DON'T DO THIS. JUST USE ENTITY FRAMEWORK
        public List<Book> GetBooks();
        public Book AddBook(Book b);
        public bool DeleteBook(int id);
        public bool UpdateBook(int id, Book updated);
    }
}
