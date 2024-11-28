using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Internship_4_MarketplaceApp.Data.Entities;
using Internship_4_MarketplaceApp.Data.Entities.Models.Enums;

namespace Internship_4_MarketplaceApp.Domain.Repositorioes
{
    public class CuponsRepository
    {

        public static float GetDiscount(Marketplaces marketplace, string code, Category category)
        {
            foreach (var cupon in marketplace.Cupons)
            {
                if(cupon.ExpirationDate < DateTime.Now)
                    continue;

                if (cupon.Code == code && cupon.Category == category)
                    return cupon.Discount;
            }
            return 0;
        }
    }
}
