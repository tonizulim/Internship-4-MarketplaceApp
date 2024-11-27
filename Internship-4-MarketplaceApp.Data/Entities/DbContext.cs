using Internship_4_MarketplaceApp.Data.Entities.Models.Enums;
using Internship_4_MarketplaceApp.Data.Entities.Models.Users;
using Internship_4_MarketplaceApp.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Policy;

namespace Internship_4_MarketplaceApp.Data.Entities
{
    public static class DbContext
    {
        public class Context
        {
            public List<Sellers> Sellers { get; set; }
            public List<Products> Products { get; set; }
            public List<Transaction> Transactions { get; set; }
            public List<Buyers> Buyers { get; set; }
        }
    }
}
