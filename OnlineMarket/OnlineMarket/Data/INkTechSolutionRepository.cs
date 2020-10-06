using DutchTreat.Data.Entities;
using System.Collections.Generic;

namespace OnlineMarket.Data
{
    public interface INkTechSolutionRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetAllProductsByCategory(string category);
        bool SaveChanges();
        IEnumerable<Order> GetAllOrders();
    }
}