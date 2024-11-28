using Internship_4_MarketplaceApp.Data.Entities;
using Internship_4_MarketplaceApp.Data.Entities.Models.Users;
using Internship_4_MarketplaceApp;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Internship_4_MarketplaceApp.Domain.Repositorioes
{
    public class BuyerRepository
    {
        public static bool CheckIfBuyerExists(Marketplaces marketplace, string email, string name)
        {
            foreach (var buyer in marketplace.Buyers)
            {
                if (buyer.Email == email && buyer.Name == name)
                    return true;
            }
            return false;
        }

        public static bool CheckIfBuyerEmailExists(Marketplaces marketplace, string email)
        {
            foreach (var buyer in marketplace.Buyers)
            {
                if (buyer.Email == email)
                    return true;
            }
            return false;
        }

        public static Guid FindBuyerGuid(Marketplaces marketplace, string email)
        {
            foreach (var buyer in marketplace.Buyers)
            {
                if (buyer.Email == email)
                    return buyer.Id;
            }
            return Guid.Empty;
        }

        public static void AddNewUser(Marketplaces marketplace, string email, string name, float amount)
        {
            var newBuyer = new Buyers(name, email, amount);
            marketplace.Buyers.Add(newBuyer);
        }

        
    }
}
