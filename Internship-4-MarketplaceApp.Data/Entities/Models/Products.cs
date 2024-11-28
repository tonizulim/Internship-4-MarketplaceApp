using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Internship_4_MarketplaceApp.Data.Entities.Models.Enums;

namespace Internship_4_MarketplaceApp.Data.Entities.Models
{
    public class Products
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public float Price { get; set; }
        public Guid SellerId { get; }
        public Category Category { get; }
        public bool IsSold { get; set; }

        public Products(string name, string description, float price, Guid sellerId, Category category) 
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Price = price;
            SellerId = sellerId;
            Category = category;
            IsSold = false;
        }
        public Products(string name, string description, float price, Guid sellerId, Category category, bool isSold)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Price = price;
            SellerId = sellerId;
            Category = category;
            IsSold = isSold;
        }
    }
}
