using Internship_4_MarketplaceApp.Data.Entities.Models.Enums;
using Internship_4_MarketplaceApp.Data.Entities.Models.Users;
using Internship_4_MarketplaceApp.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_4_MarketplaceApp.Data.Seeds
{
    internal class DatabaseSeeder
    {
        public static readonly List<Sellers> Sellers = new List<Sellers>
            {
                new Sellers("Ivan", "ivan@."),
                new Sellers("Marko", "marko@."),
                new Sellers("Petar", "petar@.")
            };

        public static readonly List<Buyers> Buyers = new List<Buyers>();
        public static readonly List<Transaction> Transactions = new List<Transaction>();
        
        public static readonly List<Products> Products = new List<Products>{
                new Products("Laptop", "Dell", 5000, Sellers[0].Id, Category.Elektronika),
                new Products("Knjiga", "Harry Potter", 100, Sellers[0].Id, Category.Knjige),
                new Products("Majica", "Nike", 50, Sellers[0].Id, Category.Odjeća)
            };
    }
}
