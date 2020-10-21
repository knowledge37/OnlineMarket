using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using OnlineMarket.Data.Entities;
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
        private readonly UserManager<StoreUser> _userManager;
        public NkTechSolutionSeeder(NkTechSolutionContext ctx,IHostingEnvironment hosting,UserManager<StoreUser>userManager)
        {
            _ctx = ctx;
            _hosting = hosting;
            _userManager = userManager;
        }
        public async Task SeedAsync()
        {
            _ctx.Database.EnsureCreated();
            //
            StoreUser user =await _userManager.FindByEmailAsync("Shawn@dutchtreat.com");
            if (user == null)
            {

                user = new StoreUser()
                {
                    FirstName = "Shawn",
                    Lastname = "Wildermuth",
                    Email="Shawn@dutchtreat.com",
                    UserName="Shawn@dutchtreat.com"
                };
                var result=await  _userManager.CreateAsync(user, "P@ssw0rd!");
                if (result!= IdentityResult.Success)
                {

                    throw new InvalidOperationException("couldnt create a new user in a seeder");
                }
            }

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
                    order.User = user;
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
