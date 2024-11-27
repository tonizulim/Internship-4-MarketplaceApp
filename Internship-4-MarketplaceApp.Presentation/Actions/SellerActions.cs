using Internship_4_MarketplaceApp.Data.Entities;
using Internship_4_MarketplaceApp.Presentation.Helpers;
using Internship_4_MarketplaceApp.Domain.Repositorioes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_4_MarketplaceApp.Presentation.Actions
{
    internal class SellerActions
    {

        public static void AddProduct(Marketplaces marketplace, Guid sellerId)
        {
            Console.Write("Unesite ime proizvoda: ");
            var name = Reader.StringInput();

            Console.Write("Unesite opis proizvoda: ");
            var description = Reader.StringInput();

            Console.Write("Unesite cijenu proizvoda: ");
            var price = Reader.NumInput(5, 0);
            while(price<=0) {
                Console.WriteLine("Cijena mora biti veća od 0");
                price = Reader.NumInput(5, 0);
            }

            Console.Write("Unesite kategoriju proizvoda: ");
            var category = Reader.CategoryInput();

            ProductRepository.AddProduct(marketplace, name, description, price, category, sellerId);
        }

        public static void ShowAllProducts(Marketplaces marketplace, Guid sellerId)
        {
            var SellerProducts = ProductRepository.GetSellerProducts(marketplace, sellerId);

            foreach (var product in SellerProducts)
            {
                string isSold = product.Sold ? "Prodano" : "Nije prodano";
                Console.WriteLine($"{product.Name} {isSold}");
            }
            Console.WriteLine("\nPritisni enter za nastavak");
            Console.ReadLine();
        }
    }
}
