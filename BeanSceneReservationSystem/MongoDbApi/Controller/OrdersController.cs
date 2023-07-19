using BeanSceneReservationSystem.Data;
using BeanSceneReservationSystem.MongoDbApi.Models;
using BeanSceneReservationSystem.MongoDbApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BeanSceneReservationSystem.MongoDbApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {   
        private readonly IOrderService _orderService;
        protected readonly ApplicationDbContext _context;
        public OrdersController(ApplicationDbContext context, IOrderService orderService)
        {
            _context = context;
            _orderService = orderService;
        }
        // GET: api/<OrdersController>
        [HttpGet]
        public ActionResult<List<Order>> Get()
        {
            
            
            return _orderService.Get();
        }

        // GET api/orders/tables
        [HttpGet("tables")]
        public async Task<JsonResult> GetTable()
       {
            var result = await _context.RestaurantTables
                .Select(t => new
                {
                    t.Id,
                    areaname = t.Area.Name,
                    areaid = t.Area.Id,

                    t.Name
                })
                .ToListAsync();

            return new JsonResult(result);
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public ActionResult<Order> Get(string id)
        {
            var order = _orderService.Get(id);
            if (order == null)
            {
                return NotFound($"Product with this id = {id} not found");
            }
            return order;
        }

        // POST api/<OrdersController>
        [HttpPost]
        public ActionResult<Order> Post([FromBody] Order order)
            {
            _orderService.Create(order);
            return CreatedAtAction(nameof(Get), new { id = order.Id }, order);
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public ActionResult<Order> Put(string id, [FromBody] Order order)
        {
            var existingOrder = _orderService.Get(id);

            if (existingOrder == null)
            {
                return NotFound($"Order with Id = {id} not found");
            }

            _orderService.Update(id, order);
            return Ok($"Order with Id = {id} has been edited");
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public ActionResult<Order> Delete(string id)
        {
            var order = _orderService.Get(id);

            if (order == null)
            {
                return NotFound($"Product with Id = {id} not found");
            }

            _orderService.Delete(id);
            return Ok($"Order with Id = {id} deleted");
        }
    }
}
