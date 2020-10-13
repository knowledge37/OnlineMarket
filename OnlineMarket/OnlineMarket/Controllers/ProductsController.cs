using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineMarket.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductsController : Controller
    {
        public readonly INkTechSolutionRepository _repository;
        public readonly ILogger<ProductsController> _logger;
        
        public ProductsController(INkTechSolutionRepository repository, ILogger<ProductsController> logger)
        {
            {
                _repository = repository;
                _logger = logger;
            }

        }
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<Product>> Get()
        {
            try
            {
                return Ok(_repository.GetAllProducts().First());
            }
            catch (Exception ex)
            {

                _logger.LogError($"failed to get all Products{ex}");
                return BadRequest("failed to get all Products");
            }
        }
        
    }
}
