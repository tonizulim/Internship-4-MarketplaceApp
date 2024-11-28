using Internship_4_MarketplaceApp.Data.Entities.Models.Users;
using Internship_4_MarketplaceApp.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Internship_4_MarketplaceApp.Data.Seeds;

namespace Internship_4_MarketplaceApp.Data.Entities
{
    public class Marketplaces
    {
        public List<Sellers> Sellers { get; set; } = DatabaseSeeder.Sellers;
        public List<Products> Products { get; set; } = DatabaseSeeder.Products;
        public List<Buyers> Buyers { get; set; } = DatabaseSeeder.Buyers;
        public List<Transaction> Transactions { get; set; } = DatabaseSeeder.Transactions;
        public List<Cupons> Cupons { get; set; } = DatabaseSeeder.Cupons;

    }
}
