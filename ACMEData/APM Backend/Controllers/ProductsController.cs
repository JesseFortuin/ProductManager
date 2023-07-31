using ACMEData.Application;
using Microsoft.AspNetCore.Mvc;

namespace APM_Backend.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductFacade productsFacade;

        public ProductsController(IProductFacade productsFacade)
        {
            this.productsFacade = productsFacade;
        }

        [HttpGet("products")]
        public ActionResult GetProducts()
        {
            var products = productsFacade.GetProducts();

            return Ok(products);
        }
    }
}
