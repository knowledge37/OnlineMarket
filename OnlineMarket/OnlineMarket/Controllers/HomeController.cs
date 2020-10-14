using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineMarket.Data;
using OnlineMarket.Models;

namespace OnlineMarket.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INkTechSolutionRepository _repository;
        private readonly NkTechSolutionContext _ctx;
        public HomeController(ILogger<HomeController> logger, NkTechSolutionContext ctx, INkTechSolutionRepository repository)
        {
            _logger = logger;
            _repository = repository;
            _ctx = ctx;
        }

        public IActionResult Index()
        {
            var result = _ctx.Products.ToList();
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        //[HttpPost("Contact")]
        public IActionResult Contact()
        {
            //if (ModelState.IsValid)
            //{
             
            //}
            //else
            //{

            //}
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [Authorize]
        public IActionResult Shop()
        {
            //var result = from p in _context.Products
            //             orderby p.Category
            //             select p;
            var result = _repository.GetAllProducts();
            return View(result);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {/* Name = Activity.Current?.Id ?? HttpContext.TraceIdentifier*/ });
        }
    }
}
