using Internship_4_MarketplaceApp.Data.Entities;
using Internship_4_MarketplaceApp.Domain.Repositorioes;
using Internship_4_MarketplaceApp.Presentation.Actions;
using Internship_4_MarketplaceApp.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_4_MarketplaceApp.Presentation.Menu
{
    public class SellerMenu
    {
        public static void DisplaySellerMenu(string email,Marketplaces marketplace)
        {
            Guid sellerId = SellerRepository.FindSellerGuid(email, marketplace);
            int option = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Prodavač");
                Console.WriteLine("1. Dodaj proizvod\n2. Pregled svih proizvoda u vlasništvu prodavača\n3. Pregled ukupne zarade od prodaje\n4. Pregled prodanih proizvoda po kategoriji\n5. Pregled zarade u određenom vremenskom razdoblju\n6. Odjava");
                option = Reader.NumInput(1, 6);

                switch (option)
                {
                    case 1:
                        SellerActions.AddProduct(marketplace, sellerId);
                        break;
                    case 2:
                        SellerActions.ShowAllProducts(marketplace, sellerId);
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    default:
                        break;
                }

                } while (option != 6);
        }
    }
}
