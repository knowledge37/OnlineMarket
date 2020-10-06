using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMarket.Data
{
    public class NkTechSolutionSeeder
    {
        private readonly NkTechSolutionContext _ctx;
        private readonly IHostingEnvironment _hosting;
        public NkTechSolutionSeeder(NkTechSolutionContext ctx,IHostingEnvironment hosting)
        {
            _ctx = ctx;
            _hosting = hosting;
        }
        public void Seed()
        {
            _ctx.Database.EnsureCreated();
            if (!_ctx.Products.Any())
            {
                //sample data needed
                var filepath = Path.Combine(_hosting.ContentRootPath,"Data/Art.json");
                var json = File.ReadAllText(filepath);
                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
                _ctx.Products.AddRange(products);

                var order = _ctx.Orders.Where(o => o.Id == 1).FirstOrDefault();
                if(order != null)
                {
                    order.Items = new List<OrderItem>()
                    {
                        new OrderItem()
                        {
                            Product=products.First(),
                            Quantity=5,
                            UnitPrice=products.First().Price

                        }
                    };
                }

                _ctx.SaveChanges();
            }
        }
    }
}
