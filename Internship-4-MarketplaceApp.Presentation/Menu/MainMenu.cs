using Internship_4_MarketplaceApp.Data.Entities;
using Internship_4_MarketplaceApp.Presentation.Actions;
using Internship_4_MarketplaceApp.Presentation.Helpers;
using System;


namespace Internship_4_MarketplaceApp.Presentation.Menu
{
    public class MainMenu
    {
        public static void DisplayMainMenu(Marketplaces marketplace)
        {
            int option = -1;
            do
            {
                Console.Clear();
                Console.WriteLine("Marketplace\n1. Registracija\n2. Prijava\n3. Izlaz");
                Console.Write("Odaberi opciju: ");

                option = Reader.NumInput(1, 3);
                switch (option)
                {
                    case 1:
                        Register.DisplayRegister(marketplace);
                        break;
                    case 2:
                        Login.DisplayLogIn(marketplace);
                        break;
                    default:
                        break;
                }
            } while (option != 3);
        }
    }
}


