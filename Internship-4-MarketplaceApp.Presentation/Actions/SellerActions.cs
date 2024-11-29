using Internship_4_MarketplaceApp.Data.Entities;
using Internship_4_MarketplaceApp.Presentation.Helpers;
using Internship_4_MarketplaceApp.Domain.Repositorioes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Internship_4_MarketplaceApp.Data.Entities.Models;

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

        public static void ProfitInTimeRange(Marketplaces marketplace, Guid sellerId)
        {
            Console.Clear();
            Console.WriteLine("Profit u odabranom vremenskom razdoblju");

            Console.Write("Unesi pocetni datum (YYYY-MM-DD): ");
            var startDate = Reader.NewDate();
            while(startDate > DateTime.Now)
            {
                Console.WriteLine("Datum ne moze biti iz buducnosti!");
                Console.Write("Unesi ponovno: ");
                startDate = Reader.NewDate();
            }

            Console.Write("Unesi krajnji datum (YYYY-MM-DD): ");
            var endDate = Reader.NewDate();
            while (endDate < startDate || endDate > DateTime.Now)
            {
                Console.WriteLine($"Datum mora biti iz perioda {startDate.ToString("yyyy-MM-dd")} - {DateTime.Now.ToString("yyyy-MM-dd")}");
                Console.Write("Unesi ponovno: ");
                endDate = Reader.NewDate();
            }

            var sellersTransactions = marketplace.Transactions.Where(transaction => transaction.SellerId == sellerId && transaction.IsReturned == false).ToList();
            
            float profit = 0;
            foreach (var transaction in sellersTransactions)
            {
                if (transaction.Date >= startDate && transaction.Date <= endDate)
                    profit += transaction.Price; 
            }

            Console.WriteLine($"Profit u razdoblju od {startDate.ToString("yyyy-MM-dd")} do {endDate.ToString("yyyy-MM-dd")} je {profit}");
            Console.WriteLine("\nUnesi enter za nastavak");
            Console.ReadLine();
        }

        public static void EditProductPrice(Marketplaces marketplace, Guid sellerId)
        {
            Console.Clear();
            Console.WriteLine("Promijeni cijenu proizvoda");

            Console.WriteLine("\nId - Naziv - Cijena");
            
            var products = marketplace.Products.Where(product => product.SellerId == sellerId && product.IsSold == false).ToList();

            foreach (var product in products)
            {
                Console.WriteLine($"{product.Id} - {product.Name} - {product.Price}");
            }

            Console.Write("\nUnesi id proizvoda: ");
            var productId = Reader.StringInput();

            var targetProduct = marketplace.Products.FirstOrDefault(product => product.Id.ToString() == productId && product.SellerId == sellerId);
            if (targetProduct == null)
            {
                Console.WriteLine("Proizvod ne postoji!");
                Console.WriteLine("\nUnesi enter za nastavak");
                Console.ReadLine();
                return;
            }

            Console.Write("Unesi novu cijenu: ");
            float.TryParse(Console.ReadLine(), out var newPrice);
            while (newPrice <= 0)
            {
                Console.WriteLine("Neispravan unos!");
                Console.Write("Unesi ponovno: ");
                float.TryParse(Console.ReadLine(), out newPrice);
            }

            Console.WriteLine($"Jeste li sigurni da želite promijeniti cijenu proizvoda {targetProduct.Name} na {newPrice} (y/n): ");
            if (!Reader.YNanswer())
            {
                Console.WriteLine("Poništena promjena!\n\nPritisni enter za nastavak");
                Console.ReadLine();
                return;
            }

            targetProduct.Price = newPrice;

            Console.WriteLine("Cijena proizvoda uspješno promijenjena\n\nPritisni enter za nastavak");
            Console.ReadLine();
        }
    }
}
