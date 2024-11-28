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
    public class SellerActions
    {
        public static void AddNewProduct(Marketplaces marketplace, Guid sellerId)
        {
            Console.Clear();
            Console.WriteLine("Dodaj novi proizvod");
            Console.Write("Unesi naziv proizvoda: ");
            var name = Reader.StringInput();

            Console.Write("Unesi opis proizvoda: ");
            var description = Reader.StringInput();

            Console.Write("Unesi cijenu proizvoda: ");
            float.TryParse(Console.ReadLine(), out var amount);
            while (amount <= 0)
            {
                Console.WriteLine("Neispravan unos!");
                Console.Write("Unesi ponovno: ");
                float.TryParse(Console.ReadLine(), out amount);
            }

            var category = Reader.CategoryInput();

            Console.WriteLine($"Jeste li sigurni da želite dodati proizvod {name} - {description} - {amount} - {category} (y/n): ");
            if (!Reader.YNanswer())
            {
                Console.WriteLine("Dodavanje proizvoda nije uspjelo\n\nPritisni enter za nastavak");
                Console.ReadLine();
                return;
            }

            ProductRepository.AddNewProduct(marketplace, sellerId, name, description, amount, category);
            Console.WriteLine("Proizvod uspješno dodan\n\nPritisni enter za nastavak");
            Console.ReadLine();
        }

        public static void ShowSellersProductsForSale(Marketplaces marketplace, Guid sellerId)
        {
            Console.Clear();
            Console.WriteLine("Dostupni proizvodi");
            Console.WriteLine("\nnaziv - cijena - opis - status");
            var products = marketplace.Products.Where(product => product.SellerId == sellerId).ToList();

            foreach (var product in products)
            {
                var status = product.IsSold ? "prodano" : "nije prodano";
                Console.WriteLine($"{product.Name} - {product.Price} - {product.Description} - {status}");
            }
            Console.WriteLine("\nUnesi enter za nastavak");
            Console.ReadLine();
        }
        public static void SoldProductsByCategory(Marketplaces marketplace, Guid sellerId)
        {
            Console.Clear();
            Console.WriteLine("Prodani proizvodi po kategorijama");

            Console.WriteLine("Unesi kategoriju: ");
            var category = Reader.CategoryInput();

            Console.WriteLine($"Odabrana kategorija: {category}");
            Console.WriteLine("\nnaziv - opis - cijena");

            var products = marketplace.Products.Where(product => product.SellerId == sellerId && product.Category == category && product.IsSold == true).ToList();

            foreach (var product in products)
            {
                Console.WriteLine($"{product.Name} - {product.Description} - {product.Price}");
            }

            Console.WriteLine("\nUnesi enter za nastavak");
            Console.ReadLine();
        }
    }
}
