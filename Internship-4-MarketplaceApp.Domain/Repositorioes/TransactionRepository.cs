using System;
using System.Linq;
using Internship_4_MarketplaceApp.Data.Entities;
using Internship_4_MarketplaceApp.Data.Entities.Models;

namespace Internship_4_MarketplaceApp.Domain.Repositorioes
{
    public class TransactionRepository
    {
        public static bool BuyProduct(Marketplaces marketplace, Guid buyerId, Products product, float discount)
        {
            if (discount == 0) {
                discount = 1;
            }

            if (buyerId == Guid.Empty)
                return false;

            if (product.IsSold)
            {
                Console.WriteLine("Proizvod je vec prodan");
                return false;
            }

            var buyer = marketplace.Buyers.FirstOrDefault(buyers => buyers.Id == buyerId);
            var seller = marketplace.Sellers.FirstOrDefault(sellers => sellers.Id == product.SellerId);

            if (buyer.Saldo < product.Price*discount)
            {
                Console.WriteLine("Nedovoljan iznos na racunu!");
                return false;
            }

            var newTransaction = new Transaction(buyerId, product.SellerId, product.Id, (float)product.Price * discount);

            marketplace.Transactions.Add(newTransaction);

            buyer.Saldo -= product.Price*discount;
            seller.Earned += product.Price * discount * (float)0.95;

            product.IsSold = true;

            Console.WriteLine("Proizvod uspjesno kupljen!");
            return true;
        }

        public static void ReturnItem(Marketplaces marketplace, Guid buyerId, Guid productId)
        {
            var transaction = marketplace.Transactions.LastOrDefault(transactions => transactions.BuyerId == buyerId && transactions.ProductId == productId);
            
            var returnProduct = marketplace.Products.FirstOrDefault(products => products.Id == productId);
            var buyer = marketplace.Buyers.FirstOrDefault(buyers => buyers.Id == buyerId);
            var seller = marketplace.Sellers.FirstOrDefault(sellers => sellers.Id == returnProduct.SellerId);

            buyer.Saldo += transaction.Price*(float)0.8;
            seller.Earned -= transaction.Price * (float)0.8;
            returnProduct.IsSold = false;
            transaction.IsReturned = true;

            return;
        }
    }
}
