using CommerceCommon.Interfaces;
using CommerceCommon.Model;
using CommerceCommon.Response;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProduct productService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts(bool featured)
        {
            var products = await productService.GetAllProducts(featured);
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<Response>> AddProduct(Product? requestObject) 
        {
            if (requestObject is null) return BadRequest("Request object is null");
            var response = await productService.AddProduct(requestObject);
            return Ok(response);
        }
    }
}