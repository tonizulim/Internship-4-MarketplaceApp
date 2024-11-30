using System;

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

        public bool IsReturned { get; set; }

        public Transaction(Guid buyerId, Guid sellerId, Guid productId, float price)
        {
            Id = Guid.NewGuid();
            BuyerId = buyerId;
            SellerId = sellerId;
            ProductId = productId;
            Date = DateTime.Now;
            Price = price;
            IsReturned = false;
        }
        public Transaction(Guid buyerId, Guid sellerId, Guid productId, float price, DateTime date)
        {
            Id = Guid.NewGuid();
            BuyerId = buyerId;
            SellerId = sellerId;
            ProductId = productId;
            Date = date;
            Price = price;
            IsReturned = false;
        }

    }
}
