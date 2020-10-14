using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineMarket.Data;
using OnlineMarket.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineMarket.Controllers
{
    [Route("/api/orders/{orderid}/items")]
    public class OrderItemsController : Controller
    {
        private readonly INkTechSolutionRepository _repository;
        private readonly ILogger<OrderItemsController> _logger;
        private readonly IMapper _mapper;
        public OrderItemsController(INkTechSolutionRepository repository, ILogger<OrderItemsController> logger,IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

            [HttpGet]
        public IActionResult Get(int orderId)
        {
            var order = _repository.GetOrderById(orderId);
            if (order != null)
            {
                return Ok(_mapper.Map<IEnumerable<OrderItem>,IEnumerable<OrderItemViewmodel>>(order.Items));
            }
            else
            {
                return NotFound();
            }
           
        }
        [HttpGet("{id}")]
        public IActionResult Get(int orderId, int id)
        {
            var order = _repository.GetOrderById(orderId);
            if (order != null)
            {
                var item = order.Items.Where(i => i.Id == id).FirstOrDefault();
                if (item != null)
                {
                return Ok(_mapper.Map<OrderItem,OrderItemViewmodel>(item));
                }
            }
            
                return NotFound();
            
        }
    }
}
