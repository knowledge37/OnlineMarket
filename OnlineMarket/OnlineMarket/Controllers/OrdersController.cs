using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineMarket.Data;
using OnlineMarket.Models;

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
        [HttpPost]
        public IActionResult Post([FromBody]OrderViewModel model)
        {
            //add it to the db
            try
            {
                if (ModelState.IsValid)
                {
                    var newOrder = new Order()
                    {
                        OrderDate = model.OrderDate,
                         OrderNumber=model.OrderNumber,
                         Id= model.OrderId
                    };

                    if (newOrder.OrderDate == DateTime.MinValue)
                    {
                        newOrder.OrderDate = DateTime.Now;
                    }

                    _repository.AddEntity(newOrder);
                    if (_repository.SaveAll())
                    {
                        var vm = new OrderViewModel()
                        {
                            OrderId = newOrder.Id,
                            OrderDate = newOrder.OrderDate,
                            OrderNumber = newOrder.OrderNumber
                        };
                        return Created($"/api/orders/[{vm.OrderId}", vm);
                    }
                }else
                {
                    return BadRequest(ModelState);
                }
                
               
            }
            catch (Exception ex)
            {

                _logger.LogError($"failed to get new orders{ex}");
            }
            return BadRequest("failed to save new order");
        }

    }
}
