using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Product.API.Models;

namespace Product.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet("list")]
        public IActionResult Get()
        {
            return Ok(ProductDto.GetProducts());
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            return Ok(ProductDto.GetProducts().FirstOrDefault(r => r.Id == id));
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] ProductDto product)
        {
            //todo: save process
            return Ok(product); 
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] ProductDto product)
        {
            //todo: update process
            return Ok(product);
        }
    }
}
