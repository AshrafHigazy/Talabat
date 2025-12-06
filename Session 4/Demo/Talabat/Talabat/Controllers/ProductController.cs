using DomanLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Talabat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet("{id}")]// GET: Base URL/api/Product?id=5
        public ActionResult<Product> Get(int id)
        {
            return new Product { Id = id };
        }

        [HttpGet]// GET: Base URL/api/Product
        public ActionResult<Product> GetAll()
        {
            return new Product() { Id = 20 };
        }

        [HttpPost] // POST: Base URL/api/Product
       public ActionResult<Product> AddProduct(Product product)
        {
            return new Product();
        }
        [HttpPost("brand")] // POST: Base URL/api/Product/brand
        public ActionResult<Product> AddBrand(Product product)
        {
            return new Product();
        }
        [HttpPost] // PUT: Base URL/api/Product
        public ActionResult<Product> UpdateProduct(Product product)
        {
            return new Product();
        }
        [HttpDelete]
        public ActionResult DeleteProduct(int id)
        {
            return Ok();
        }

    }
}
