using IdentityProvaider.API.AplicationServices;
using IdentityProvaider.API.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Dynamic;

namespace IdentityProvaider.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly ProductService productSercvices;

        public ProductController(ProductService userServices)
        {
            this.productSercvices = userServices;
        }

        [HttpPost("createProduct")]
        public async Task<IActionResult> CreateProduct()
        {
            return Ok(await productSercvices.CreateProduct());
        }
     

        [HttpGet("getProductsByRange")]
        public async Task<IActionResult> GetUser(int numI, int numF)
        {
            return Ok(await productSercvices.GetProductsByNum(numI, numF));
        }

        
    }

}
