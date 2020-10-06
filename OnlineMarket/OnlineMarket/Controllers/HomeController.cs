using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineMarket.Data;
using OnlineMarket.Models;

namespace OnlineMarket.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NkTechSolutionContext _context;
        private readonly NkTechSolutionContext _ctx;
        public HomeController(ILogger<HomeController> logger, NkTechSolutionContext ctx, NkTechSolutionContext context)
        {
            _logger = logger;
            _context = context;
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
        public IActionResult Shop()
        {
            var result = from p in _context.Products
                         orderby p.Category
                         select p;
            return View(result.ToList());
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {/* Name = Activity.Current?.Id ?? HttpContext.TraceIdentifier*/ });
        }
    }
}
