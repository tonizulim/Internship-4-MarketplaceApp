using Internship_4_MarketplaceApp.Data.Entities;
using Internship_4_MarketplaceApp.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_4_MarketplaceApp.Presentation.Menu
{
    internal class BuyerMenu
    {
        public static void DisplayBuyerMenu(string email, Marketplaces marketplace)
        {
            int option = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Kupac");
                Console.WriteLine("1.");
                option = Reader.NumInput(1, 6);

                switch (option)
                {
                    
                    default:
                        break;
                }

            } while (option != 6);
        }
    }
}
