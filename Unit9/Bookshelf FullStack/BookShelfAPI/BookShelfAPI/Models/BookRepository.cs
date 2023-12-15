using System;

namespace BookShelfAPI.Models
{
    public class BookRepository : IBookRepository
    {
        //WE DON'T DO THIS. JUST USE ENTITY FRAMEWORK
        public BookRepository()
        {
            using (var context = new BookshelfDbContext())
            {
                if (context.Books.Count() == 0)
                {
                    var books = new List<Book>
                {
                new Book
                {
                    Id = 1,
                    Title ="How to code",
                    Author = "Grant Chirpus",
                    Pages = 9841,
                    LentOut = false
                },
                new Book
                {
                    Id = 2,
                    Title ="How to Debug",
                    Author = "Grant Chirpus",
                    Pages = 4322,
                    LentOut = true
                },
                };

                    context.Books.AddRange(books);
                    context.SaveChanges();
                }
                
            }
        }
        public List<Book> GetBooks()
        {
            using (var context = new BookshelfDbContext())
            {
                var list = context.Books.ToList();
                return list;
            }
        }
        public Book AddBook(Book b)
        {
            using (var context = new BookshelfDbContext())
            {
                context.Books.Add(b);
                context.SaveChanges();
                return b;
            }
        }

        public bool DeleteBook(int id)
        {
            using (var context = new BookshelfDbContext())
            {
                Book result = context.Books.FirstOrDefault(b => b.Id == id);
                if(result != null)
                {
                    context.Books.Remove(result);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool UpdateBook(int id, Book updated)
        {
            using (var context = new BookshelfDbContext())
            {
                if (context.Books.Any(b => b.Id == id))
                {
                    context.Books.Update(updated);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
