using Internship_4_MarketplaceApp.Data.Entities;
using Internship_4_MarketplaceApp.Data.Entities.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Internship_4_MarketplaceApp.Domain.Repositorioes
{
    public class SellerRepository
    {
        public static bool CheckIfSellerEmailExists(Marketplaces marketplace, string email)
        {
            foreach (var seller in marketplace.Sellers)
            {
                if (seller.Email == email)
                    return true;
            }
            return false;
        }

    }
}
