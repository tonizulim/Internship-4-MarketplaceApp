using Internship_4_MarketplaceApp.Data.Entities;
using Internship_4_MarketplaceApp.Domain.Repositorioes;
using Internship_4_MarketplaceApp.Presentation.Helpers;
using Internship_4_MarketplaceApp.Presentation.Menu;
using System;

namespace Internship_4_MarketplaceApp.Presentation.Actions
{
    public class Login
    {
        public static void DisplayLogIn(Marketplaces marketplace)
        {
            Console.Clear();
            Console.WriteLine("Prijavi se");
            Console.Write("Unesi email: ");
            var email = Reader.EmailInput();


            Console.Write("Unesi ime: ");
            var name = Reader.StringInput();

            if (BuyerRepository.CheckIfBuyerExists(marketplace, email, name))
            {
                BuyerMenu.DisplayBuyerMenu(marketplace, email);
                return;
            }
            else if (SellerRepository.CheckIfSellerExists(marketplace, email, name))
            {
                SellerMenu.DisplaySellerMenu(marketplace, email);
                return;
            }

            Console.WriteLine("Korisnik ne postoji\n\nPritisni enter za nastavak");
            Console.ReadLine();
        }
    }
}
