using Internship_4_MarketplaceApp.Data.Entities;
using Internship_4_MarketplaceApp.Domain.Repositorioes;
using Internship_4_MarketplaceApp.Presentation.Helpers;
using System;


namespace Internship_4_MarketplaceApp.Presentation.Actions
{
    public class Register
    {
        public static void DisplayRegister(Marketplaces marketplace)
        {
            Console.Clear();
            Console.WriteLine("Registriraj se");


            Console.Write("Unesi email: ");
            var email = Reader.EmailInput();
            while (BuyerRepository.CheckIfBuyerEmailExists(marketplace, email) || SellerRepository.CheckIfSellerEmailExists(marketplace, email))
            {
                Console.WriteLine("Email već postoji");
                Console.Write("Unesi drugi email: ");
                email = Reader.EmailInput();
            }

            Console.Write("Unesi ime: ");
            var name = Reader.StringInput();

            Console.Write("Registriraj se kao:\n1. Prodavac\n2. Kupac\n");
            var userType = Reader.NumInput(1, 2);

            float amount = 0;
            if (userType == 2)
            {
                Console.Write("Unesi pocetni iznos: ");
                float.TryParse(Console.ReadLine(), out amount);
                while (amount <= 0)
                {
                    Console.WriteLine("Neispravan unos!");
                    Console.Write("Unesi ponovno: ");
                    float.TryParse(Console.ReadLine(), out amount);
                }
            }

            Console.WriteLine($"Jeste li sigurni da želite registrirati {name} - {email} (y/n): ");
            if (!Reader.YNanswer())
            {
                Console.WriteLine("Registracija nije uspjela\n\nPritisni enter za nastavak");
                Console.ReadLine();
                return;
            }

            if (userType == 1)
                SellerRepository.AddNewUser(marketplace, email, name);
            else
                BuyerRepository.AddNewUser(marketplace, email, name, amount);

            Console.WriteLine("Uspješno ste se registrirali\n\nPritisni enter za nastavak");

            Console.ReadLine();

        }
    }
}
