using Internship_4_MarketplaceApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_4_MarketplaceApp.Domain.Repositorioes
{
    public class BuyerRepository
    {
        public static bool CheckIfBuyerExists(string email, string name, Marketplaces marketplace)
        {
            foreach (var buyer in marketplace.Buyers)
            {
                if (buyer.Email == email && buyer.Name == name)
                    return true;
            }
            return false;
        }
    }
}
