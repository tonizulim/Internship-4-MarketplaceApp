using Internship_4_MarketplaceApp.Data.Entities.Models;
using Internship_4_MarketplaceApp.Data.Entities;
using Internship_4_MarketplaceApp.Data.Entities.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_4_MarketplaceApp.Domain.Repositorioes
{
    public class ProductRepository
    {

        public static List<Products> ProductsForSale(Marketplaces marketplace)
        {
            var products = marketplace.Products.Where(product => product.IsSold == false).ToList();

            return products;
        }
    }
}
