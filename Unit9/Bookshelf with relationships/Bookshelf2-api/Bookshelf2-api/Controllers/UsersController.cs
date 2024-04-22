using Bookshelf2_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookshelf2_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        Bookshelf2Context dbContext = new Bookshelf2Context();

        [HttpGet()]
        public IActionResult GetAll(string? username = null)
        {
            List<User> result = dbContext.Users.ToList();
            if(username != null && username != "")
            {
                result = result.Where(u => u.Username == username).ToList();
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            User result = dbContext.Users.Find(id);
            if (result == null) { return NotFound(); }
            return Ok(result);
        }

        [HttpPost()]
        public IActionResult AddUser([FromBody] User u)
        {
            dbContext.Users.Add(u);
            dbContext.SaveChanges();

            return CreatedAtAction($"/Users/{u.Id}", u);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            User result = dbContext.Users.Find(id);
            if (result == null) { return NotFound(); }
            dbContext.Users.Remove(result);
            dbContext.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User u)
        {
            if (id != u.Id) { return BadRequest(); }
            if (dbContext.Users.Find(id) == null) { return NotFound(); }
            dbContext.Users.Update(u);
            dbContext.SaveChanges();

            return NoContent();
        }
    }
}
