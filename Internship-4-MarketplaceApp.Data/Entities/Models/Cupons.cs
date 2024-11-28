using System;
using Internship_4_MarketplaceApp.Data.Entities.Models.Enums;

namespace Internship_4_MarketplaceApp.Data.Entities.Models
{
    public class Cupons
    { 
        public Guid Id { get; }
        public string Code { get; }
        public int Discount { get; }
        public DateTime ExpirationDate { get; }
        public Category Category { get; }

        public Cupons(string  code, int discount, DateTime expirationDate, Category category)
        {
            Id = Guid.NewGuid();
            Code = code;
            Discount = discount;
            ExpirationDate = expirationDate;
            Category = category;
        }

    }


}
