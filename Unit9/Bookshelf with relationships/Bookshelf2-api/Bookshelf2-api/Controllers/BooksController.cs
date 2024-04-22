using Bookshelf2_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookshelf2_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        Bookshelf2Context dbContext = new Bookshelf2Context();

        [HttpGet()]
        public IActionResult GetAll(int? ownerId= null, string? q = null, bool? lentOut = null,  int? lentOutToId= null)
        {
            List<Book> result = dbContext.Books.Include(b => b.LentOutTo).ToList();
            //multiple ifs allow for filtering
            if(ownerId != null)
            {
                result = result.Where(b => b.OwnerId == ownerId).ToList();
            }
            if(q != null && q != "")
            {
                result = result.Where(b => b.Title.ToLower().Contains(q.ToLower())).ToList();
            }
            if(lentOut != null)
            {
                result = result.Where(b => b.LentOut == lentOut).ToList();
            }
            if (lentOutToId != null)
            {
                result = result.Where(b => b.LentOutToId == lentOutToId).ToList();
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Book result = dbContext.Books.Include(b => b.LentOutTo).FirstOrDefault(b => b.Id == id);
            if (result == null) { return NotFound(); }
            return Ok(result);
        }

        [HttpPost()]
        public IActionResult AddBook([FromBody]Book b)
        {
            dbContext.Books.Add(b);
            dbContext.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = b.Id}, b);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            Book result = dbContext.Books.Find(id);
            if (result == null) { return NotFound(); }
            dbContext.Books.Remove(result);
            dbContext.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody]Book b)
        {
            if(id != b.Id) { return BadRequest(); }
            if (!dbContext.Books.Any(b => b.Id == id)) { return NotFound(); }
            if(b.LentOutTo != null)
            {
                b.LentOutToId = b.LentOutTo.Id;
                b.LentOutTo = dbContext.Users.Find(b.LentOutTo.Id);
                //b.Owner = null;
            }
            else
            {
                b.LentOutToId = null;
                b.LentOutTo = null;
                //b.Owner = null;
            }
            b.Owner = dbContext.Users.Find(b.OwnerId);
            
            dbContext.Books.Update(b);
            dbContext.SaveChanges();

            return NoContent();
        }
    }
}
