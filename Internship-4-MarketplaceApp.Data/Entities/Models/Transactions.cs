using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_4_MarketplaceApp.Data.Entities.Models
{
    public class Transaction
    {
        public Guid Id { get; }
        public Guid BuyerId { get; set; }
        public Guid SellerId { get; set; }
        public Guid ProductId { get; set; }
        public DateTime Date { get; set; }
        public float Price { get; set; }

        public Transaction(Guid buyerId, Guid sellerId, Guid productId, float price)
        {
            Id = Guid.NewGuid();
            BuyerId = buyerId;
            SellerId = sellerId;
            ProductId = productId;
            Date = DateTime.Now;
            Price = price;
        }

    }
}
