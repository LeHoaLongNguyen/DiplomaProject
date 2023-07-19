using BeanSceneReservationSystem.MongoDbApi.Models;
using BeanSceneReservationSystem.MongoDbApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BeanSceneReservationSystem.MongoDbApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public ActionResult<List<Product>> Get()
        {
            return _productService.Get();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(string id)
        {
            var product = _productService.Get(id);
            if (product == null) 
            {
                return NotFound($"Product with this id = {id} not found");
            }
            return product;
        }

        // POST api/<ProductsController>
        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product product)
        {
            _productService.Create(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public ActionResult<Product> Put(string id, [FromBody] Product product)
        {
            var existingStudent = _productService.Get(id);

            if (existingStudent == null)
            {
                return NotFound($"Product with Id = {id} not found");
            }

            _productService.Update(id, product);
            return Ok($"Product with Id = {id} has been edited");
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public ActionResult<Product> Delete(string id)
        {
            var product = _productService.Get(id);

            if (product == null)
            {
                return NotFound($"Product with Id = {id} not found");
            }

            _productService.Delete(id);
            return Ok($"Product with Id = {id} deleted");
        }
    }
}
