using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant_Favs_BackEnd.Models;

namespace Restaurant_Favs_BackEnd.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        
        private OrderContext _orderContext = new OrderContext();

        [HttpGet()]
        public IActionResult getAll(string? restaurant = null, bool? orderAgain= null)
        {
            //no filter
            if(restaurant == null && orderAgain == null)
            {
                List<Order> result = _orderContext.Orders.ToList();
                return Ok(result);
            }
            //by restaurant
            else if (restaurant != null && orderAgain == null)
            {
                List<Order> result = _orderContext.Orders.Where(o => o.restaurant == restaurant).ToList();
                return Ok(result);
            }
            //by orderAgain
            else if (restaurant == null && orderAgain != null)
            {
                List<Order> result = _orderContext.Orders.Where(o => o.orderAgain == orderAgain).ToList();
                return Ok(result);
            }
            //by restaurant and orderAgain
            else
            {
                List<Order> result = _orderContext.Orders.Where(o => o.orderAgain == orderAgain && o.restaurant == restaurant).ToList();
                return Ok(result);
            }
        }

        [HttpGet("/{id}")]
        public IActionResult GetById(int id)
        {
            Order result = _orderContext.Orders.FirstOrDefault(o => o.id == id);
            if(result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpPost]
        public IActionResult AddOrder([FromBody] Order newOrder)
        {
            _orderContext.Orders.Add(newOrder);
            _orderContext.SaveChanges();
            return Created($"/Orders/{newOrder.id}", newOrder);
        }

        [HttpPut("/{id}")]
        public IActionResult UpdateById([FromBody] Order updatedOrder, int id)
        {
            if (id != updatedOrder.id)
            {
                return BadRequest();
            }
            else if (!_orderContext.Orders.Any(o => o.id == id))
            {
                return NotFound();
            }
            else
            {
                _orderContext.Orders.Update(updatedOrder);
                _orderContext.SaveChanges();
                return NoContent();
            }
        }

        [HttpDelete("/{id}")]
        public IActionResult DeleteById(int id)
        {
            Order result = _orderContext.Orders.FirstOrDefault(o => o.id == id);
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                _orderContext.Orders.Remove(result);
                return NoContent();
            }
        }
    }
}
