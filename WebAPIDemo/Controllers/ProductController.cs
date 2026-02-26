
using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Model;
using WebAPIDemo.Service;
using WebAPIDemo.Model;
using WebAPIDemo.Service;
using Microsoft.Extensions.Caching.Memory;



namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ProductController : ControllerBase
    {
        private readonly IProductService service;
       // private readonly IMemoryCache _cache;
        public ProductController(IProductService service)
        {
            this.service = service;
            //this._cache = _cache;
        }
        // GET: api/<ProductController>
        // api/Product/GetAllProducts
        [HttpGet]
        [Route("GetAllProducts")] // attribute based routing
        public IActionResult Get()
        {
            try
            {
                return new ObjectResult(service.GetAllProducts());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }


        // GET api/<ProductController>/5
        [HttpGet]
        [Route("GetProductById/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return new ObjectResult(service.GetProductById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent, ex.Message);
            }
        }

        // POST api/<ProductController>
        [HttpPost]
        [Route("AddProduct")]
        public IActionResult Post([FromBody] Product product)
        {
            try
            {
                int result = service.AddProduct(product);
                if (result == 1)
                {
                    return StatusCode(StatusCodes.Status201Created);
                }
                else
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut]
        [Route("UpdateProduct")]
        public IActionResult Put([FromBody] Product product)
        {
            try
            {
                int result = service.UpdateProduct(product);
                if (result == 1)
                {
                    return StatusCode(StatusCodes.Status200OK);

                }
                else
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete]
        [Route("DeleteProduct/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                int result = service.DeleteProduct(id);
                if (result == 1)
                {
                    return StatusCode(StatusCodes.Status200OK);

                }
                else
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
