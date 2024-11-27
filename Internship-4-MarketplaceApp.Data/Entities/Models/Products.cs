using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Internship_4_MarketplaceApp.Data.Entities.Models.Enums;

namespace Internship_4_MarketplaceApp.Data.Entities.Models
{
    public class Products
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public int Price { get; }
        public bool Sold { get; set; }
        public Guid SellerId { get; }
        public Category ItemCategory { get; }
        public int Rating { get; set; }

        public Products(string name, string description, int price, Guid seller, Category itemCategory)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Price = price;
            Sold = false;
            SellerId = seller;
            ItemCategory = itemCategory;
            Rating = 0;
        }
    }
}
