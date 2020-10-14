using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMarket.Data.Entities
{
    public class StoreUser : IdentityUser
    {
        public int FirstName { get; set; }
        public int Lastname { get; set; }
    }
}
