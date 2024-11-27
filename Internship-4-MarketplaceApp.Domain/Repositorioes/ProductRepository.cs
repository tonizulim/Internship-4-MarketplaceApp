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
        public static void AddProduct(Marketplaces marketplace, string name, string description, int price, Category category, Guid sellerId)
        {
            var product = new Products(name, description, price, sellerId, category);

            marketplace.Products.Add(product);
        }

        public static List<Products> GetSellerProducts(Marketplaces marketplace, Guid sellerId)
        {
            List<Products> SellerProducts = marketplace.Products.Where(product => product.SellerId == sellerId).ToList();
            return SellerProducts;
        }
    }
}
