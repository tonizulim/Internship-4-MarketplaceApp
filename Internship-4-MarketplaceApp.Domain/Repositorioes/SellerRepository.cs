using Internship_4_MarketplaceApp.Data.Entities;
using Internship_4_MarketplaceApp.Data.Entities.Models.Users;
using System;

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

        public static bool CheckIfSellerExists(Marketplaces marketplace, string email, string name)
        {
            foreach (var seller in marketplace.Sellers)
            {
                if (seller.Email == email && seller.Name == name)
                    return true;
            }
            return false;
        }

        public static Guid FindSellerGuid(Marketplaces marketplace, string email)
        {
            foreach (var seller in marketplace.Sellers)
            {
                if (seller.Email == email)
                    return seller.Id;
            }
            return Guid.Empty;
        }

        public static void AddNewUser(Marketplaces marketplace, string email, string name)
        {
            var newSeller = new Sellers(name, email);
            marketplace.Sellers.Add(newSeller);
        }

    }
}
