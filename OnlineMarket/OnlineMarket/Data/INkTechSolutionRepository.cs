using DutchTreat.Data.Entities;
using System.Collections.Generic;

namespace OnlineMarket.Data
{
    public interface INkTechSolutionRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetAllProductsByCategory(string category);
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int id);
        bool SaveChanges();
  
      
    }
}