using Microsoft.AspNetCore.Mvc;
using PatoShopping.API.Data.ValueObjects;
using PatoShopping.API.Model;
using PatoShopping.API.Repository.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PatoShopping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository?? throw new ArgumentNullException(nameof(repository));
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVO>>> Get()
        {
            var products = await _repository.GetAll();
            return Ok(products);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVO>> Get(long id)
        {
            var product = await _repository.FindById(id);
            if(product == null) return NotFound();

            return Ok(product);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult<ProductVO>> Post([FromBody] ProductVO productVO)
        {
            if(productVO == null) return BadRequest();
            var product = await _repository.Create(productVO);

            return Ok(product);
        }

        // PUT api/<ProductController>/5
        [HttpPut()]
        public async Task<ActionResult<ProductVO>> Put([FromBody] ProductVO productVO)
        {
            if (productVO == null) return BadRequest();
            var product = await _repository.Update(productVO);
           
            return Ok(product);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var status = await _repository.DeleteById(id);
            if(!status) return BadRequest();

            return Ok(status);
        }


        [HttpGet("modelo")]
        public IActionResult Modelo()
        {
            return Ok(new ProductVO());
        }
    }
}
