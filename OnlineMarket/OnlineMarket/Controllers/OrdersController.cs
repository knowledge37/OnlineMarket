using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineMarket.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineMarket.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        public readonly INkTechSolutionRepository _repository;
        public readonly ILogger<OrdersController> _logger;
       public OrdersController(INkTechSolutionRepository repository,ILogger<OrdersController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repository.GetAllOrders());
            }
            catch (Exception ex)
            {

                _logger.LogError($"failed to get all orders{ex}");
                return BadRequest("failed to get all orders");
            }
        }
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var order = _repository.GetOrderById(id);
                if (order != null)
                {
                    return Ok(order);
                }else
                {
                    return NotFound();
                }
              
            }
            catch (Exception ex)
            {

                _logger.LogError($"failed to get all orders{ex}");
                return BadRequest("failed to get all orders");
            }
        }

    }
}
