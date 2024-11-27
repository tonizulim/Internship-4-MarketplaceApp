using Internship_4_MarketplaceApp.Data.Entities;
using Internship_4_MarketplaceApp.Presentation.Actions;
using Internship_4_MarketplaceApp.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_4_MarketplaceApp.Presentation.Menu
{
    public class MainMenu
    {
        public static readonly Marketplaces marketplace = new Marketplaces();

        public static void DisplayMainMenu()
        {
            int option = -1;
            do
            {
                Console.Clear();
                Console.WriteLine("Marketplace");
                Console.WriteLine("1. Registracija");
                Console.WriteLine("2. Prijava");
                Console.WriteLine("3. Izlaz");
                Console.Write("Odaberi opciju: ");

                option = Reader.NumInput(1, 3);
                switch (option)
                {
                    case 1:
                        Register.RegisterUser(marketplace);
                        break;
                    case 2:
                        Login.DisplayLogIn(marketplace);
                        break;
                    case 3:
                        break;
                    default:
                        break;
                }
            } while (option != 3);

        }
    }
}


