using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_4_MarketplaceApp.Data.Entities.Models
{
    public class Transaction
    {
        public Guid ProductID { get; }
        public Guid BuyerID { get; }
        public Guid SellerID { get; }
        public DateTime Date { get; }

        public Transaction(Guid productID, Guid buyerID, Guid sellerID)
        {
            ProductID = productID;
            BuyerID = buyerID;
            SellerID = sellerID;
            Date = DateTime.Now;
        }
    }
}
