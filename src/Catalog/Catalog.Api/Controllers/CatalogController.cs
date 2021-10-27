using Catalog.Api.Entities;
using Catalog.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IProductReopsitory _productReopsitory;
        

        public CatalogController(IProductReopsitory productReopsitory)
        {
            _productReopsitory = productReopsitory;
           
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _productReopsitory.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id}",Name = "GetProduct")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _productReopsitory.GetProduct(id);
            if(product==null)
            {
                return NotFound();
            }
            return Ok(product);
            
        }
        [Route("[action]/{category}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductByCategory(string category)
        {
            var product = await _productReopsitory.GetProductByCategory(category);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);

        }
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] Product product)
        {
             await _productReopsitory.Create(product);
            return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
          

        }
        [HttpPut]
        public async Task<ActionResult<Product>> UpdateProduct([FromBody] Product product)
        {

            return Ok(await _productReopsitory.Update(product));


        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProductById(int id)
        {
            var pord = await _productReopsitory.GetProduct(id);
            return Ok(await _productReopsitory.Delete(pord));


        }

    }
}
