using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_4_MarketplaceApp.Data.Entities.Models
{
    public class Cupons
    {
        public Guid Id { get; }
        public string Code { get; }
        public double Discount { get; }
        public DateTime EndDate { get; }

        public Cupons(string code, double discount, DateTime endDate)
        {
            Id = Guid.NewGuid();
            Code = code;
            Discount = discount;
            EndDate = endDate;
        }
    }
}
