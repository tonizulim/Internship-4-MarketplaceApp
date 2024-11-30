using Internship_4_MarketplaceApp.Data.Entities;
using Internship_4_MarketplaceApp.Domain.Repositorioes;
using Internship_4_MarketplaceApp.Presentation.Actions;
using Internship_4_MarketplaceApp.Presentation.Helpers;
using System;
using System.Linq;

namespace Internship_4_MarketplaceApp.Presentation.Menu
{
    internal class BuyerMenu
    {     
        public static void DisplayBuyerMenu(Marketplaces marketplace, string email)
        {
            var buyerId = BuyerRepository.FindBuyerGuid(marketplace, email);
            int odabir = 0;
            do
            {
                Console.Clear();
                Console.WriteLine($"Kupac menu {marketplace.Buyers.FirstOrDefault(buyer => buyer.Id == buyerId).Saldo}");
                Console.WriteLine("1. Pregled proizvoda\n2. Kupi proizvod\n3. Vrati proizvod\n4. Dodavaj proizvod u listu omiljenih\n5. Pregled povijesti kupljenih proizvoda\n6. Pregled liste omiljenih proizvoda\n7. Odjava ");


                odabir = Reader.NumInput(1,7);
                switch (odabir)
                {
                    case 1:
                        BuyerAction.ShowProductsForSale(marketplace);
                        break;
                    case 2:
                        BuyerAction.BuyProduct(marketplace, buyerId);
                        break;
                    case 3:
                        BuyerAction.ReturnProduct(marketplace, buyerId);
                        break;
                    case 4:
                        BuyerAction.AddFavProduct(marketplace, buyerId);
                        break;
                    case 5:
                        BuyerAction.ShowBoughtProducts(marketplace, buyerId);
                        break;
                    case 6:
                        BuyerAction.ShowFavProducts(marketplace, buyerId);
                        break;
                    default:
                        break;
                }
            } while (odabir != 7);
        }
    }
}
