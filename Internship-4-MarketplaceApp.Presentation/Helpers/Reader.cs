using Internship_4_MarketplaceApp.Data.Entities.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_4_MarketplaceApp.Presentation.Helpers
{
    internal class Reader
    {
        public static bool YNanswer()
        {
            var userInput = Console.ReadLine().ToLower();

            while (userInput != "y" && userInput != "n")
            {
                Console.Write("unesite y/n:");
                userInput = Console.ReadLine().ToLower();
            }

            if (userInput == "y")
            {
                return true;
            }

            return false;
        }

        public static DateTime NewDate()
        {
            DateTime Date;
            bool correct = DateTime.TryParse(Console.ReadLine(), out Date);
            while (!correct)
            {
                Console.Write("Neispavan unos datuma, pokušajte ponovo (YYYY-MM-DD): ");
                correct = DateTime.TryParse(Console.ReadLine(), out Date);
            }
            return Date;
        }
        public static int NumInput(int start, int end)
        {
            int.TryParse(Console.ReadLine(), out var userInput);
            if (start >= end)
            {
                return userInput;
            }
            while (userInput < start || userInput > end)
            {
                Console.Write("Nesipravan unos! Unesi ponovno:");
                int.TryParse(Console.ReadLine(), out userInput);
            }
            return userInput;
        }

        public static string EmailInput()
        {
            var email = Console.ReadLine().ToLower();
            while (string.IsNullOrWhiteSpace(email) || int.TryParse(email, out _) || !email.Contains("@") || !email.Contains(".") || email.EndsWith("."))
            {
                Console.Write("Neispravan unos! Unesi ponovno: ");
                email = Console.ReadLine().ToLower();
            }
            return email;
        }

        public static string StringInput()
        {
            var text = Console.ReadLine().ToLower();
            while (string.IsNullOrWhiteSpace(text) || int.TryParse(text, out _))
            {
                Console.Write("Neispravan unos! Unesi ponovno: ");
                text = Console.ReadLine().ToLower();
            }
            return text;
        }

        public static Category CategoryInput()
        {
            Console.WriteLine("1. Elektronika,\n2. Odjeća,\n3. Knjige");
            var category = NumInput(1, 3);

            switch (category)
            {
                case 1:
                    return Category.Elektronika;
                case 2:
                    return Category.Odjeća;
                case 3:
                    return Category.Knjige;
                default:
                    return Category.Elektronika;    
            }
        }
    }
}

