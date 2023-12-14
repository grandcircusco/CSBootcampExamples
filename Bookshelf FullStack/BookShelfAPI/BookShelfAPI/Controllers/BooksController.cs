using BookShelfAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShelfAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        //All entity framework methods you are used to is in BookRepository.cs
        readonly IBookRepository _bookRepository;
        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

       
        [HttpGet()]
        public IActionResult GetAll(string? q = null, bool? lentOut = null)
        {
            List<Book> result;
            if(q != null)
            {
                if(lentOut != null)
                {
                    result = _bookRepository.GetBooks().Where(b=> b.LentOut == lentOut).Where(b => b.Title.ToLower().Contains(q.ToLower())).ToList();
                }
                else
                {
                    result = _bookRepository.GetBooks().Where(b => b.Title.ToLower().Contains(q.ToLower())).ToList();
                }
            }
            else
            {
                if (lentOut != null)
                {
                    result = _bookRepository.GetBooks().Where(b => b.LentOut == lentOut).ToList();
                }
                else
                {
                    result = _bookRepository.GetBooks().ToList();
                }
            }

            return Ok(result);
        }

       
        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            Book result = _bookRepository.GetBooks().FirstOrDefault(b => b.Id == id);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        //DB is in memory. Won't save changes once restarted
       
        [HttpPost()]
        public IActionResult AddBook([FromBody] Book newBook)
        {
            newBook = _bookRepository.AddBook(newBook);
            return Created($"Books/{newBook.Id}" , newBook);
        }

        //DB is in memory. Won't save changes once restarted
       
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            bool successfulDelete = _bookRepository.DeleteBook(id);
            if (successfulDelete)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        //DB is in memory. Won't save changes once restarted
       
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book updated)
        {
            if(id != updated.Id)
            {
                return BadRequest();
            }

            bool successfulUpdate = _bookRepository.UpdateBook(id, updated);
            if (successfulUpdate)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
