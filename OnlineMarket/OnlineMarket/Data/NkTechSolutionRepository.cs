using DutchTreat.Data.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMarket.Data
{
    public class NkTechSolutionRepository : INkTechSolutionRepository
    {
        private readonly NkTechSolutionContext _ctx;
        private readonly ILogger<NkTechSolutionRepository> _logger;
        public NkTechSolutionRepository(NkTechSolutionContext ctx,ILogger<NkTechSolutionRepository>logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        public object GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAllProducts()
        {
           
            try
            {
                _logger.LogInformation("GetAllProducts was called");
                return _ctx.Products
             .OrderBy(p => p.Title)
             .ToList();
            }
            catch (Exception ex)
            {

                _logger.LogError($"failed to get all product{ex}");
                return null;
            }
         
        }
        public IEnumerable<Product> GetAllProductsByCategory(String category)
        {

            return _ctx.Products
                .OrderBy(p => p.Category == category)
                .ToList();


        }
        public bool SaveAll()
        {
          return  _ctx.SaveChanges() > 0;
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        IEnumerable<Order> INkTechSolutionRepository.GetAllOrders()
        {
            return _ctx.Orders.ToList();
        }
    }
}
