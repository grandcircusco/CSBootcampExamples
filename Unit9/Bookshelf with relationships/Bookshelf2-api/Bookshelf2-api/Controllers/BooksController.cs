using Bookshelf2_api.Models;
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
            // Include ensures that the lentOutTo nested JSON is filled in
            IQueryable<Book> result = dbContext.Books.Include(b => b.LentOutTo);
            //multiple ifs allow for filtering
            if(ownerId != null)
            {
                result = result.Where(b => b.OwnerId == ownerId);
            }
            if(q != null && q != "")
            {
                result = result.Where(b => b.Title.ToLower().Contains(q.ToLower()));
            }
            if(lentOut != null)
            {
                result = result.Where(b => b.LentOut == lentOut);
            }
            if (lentOutToId != null)
            {
                result = result.Where(b => b.LentOutTo.Id == lentOutToId);
            }
            return Ok(result.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Book? result = dbContext.Books.Find(id);
            if (result == null) { return NotFound(); }
            // Ensure that the lentOutTo nested JSON is filled in
            dbContext.Entry(result).Reference(p => p.LentOutTo).Load();
            return Ok(result);
        }

        [HttpPost()]
        public IActionResult AddBook([FromBody]Book b)
        {
            // We're choosing to trust the object's ID over the LentOutToId in this case.
            b.LentOutToId = b.LentOutTo?.Id;
            // Clear out the object so we don't inadvertently overwrite values in the User table.
            b.LentOutTo = null;

            dbContext.Books.Add(b);
            dbContext.SaveChanges();

            return Created($"/Books/{b.Id}", b);
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
            // We're choosing to trust the object's ID over the LentOutToId in this case.
            b.LentOutToId = b.LentOutTo?.Id;
            // Clear out the object so we don't inadvertently overwrite values in the User table.
            b.LentOutTo = null;
            
            dbContext.Books.Update(b);
            dbContext.SaveChanges();

            return Ok(b);
        }
    }
}
