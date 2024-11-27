using Internship_4_MarketplaceApp.Data.Entities;
using Internship_4_MarketplaceApp.Domain.Repositorioes;
using Internship_4_MarketplaceApp.Presentation.Helpers;
using Internship_4_MarketplaceApp.Presentation.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_4_MarketplaceApp.Presentation.Actions
{
    public class Login
    {
        public static void DisplayLogIn(Marketplaces Marketplace)
        {
            Console.Clear();
            Console.WriteLine("Prijavi se");
            Console.Write("Unesi email: ");
            var email = Reader.EmailInput();


            Console.Write("Unesi ime: ");
            var name = Reader.StringInput();


            if (SellerRepository.CheckIfSellerExists(email, name, Marketplace))
            {
                SellerMenu.DisplaySellerMenu(email, Marketplace);
                return;
            }

            if (BuyerRepository.CheckIfBuyerExists(email, name, Marketplace))
            {
                BuyerMenu.DisplayBuyerMenu(email, Marketplace);
                return;
            }

            Console.WriteLine("Korisnik ne postoji\n\nPritisni enter za nastavak");
            Console.ReadLine();
        }
    }
}
