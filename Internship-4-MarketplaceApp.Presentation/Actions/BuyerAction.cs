using Internship_4_MarketplaceApp.Data.Entities;
using Internship_4_MarketplaceApp.Data.Entities.Models;
using Internship_4_MarketplaceApp.Domain.Repositorioes;
using Internship_4_MarketplaceApp.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Internship_4_MarketplaceApp.Presentation.Actions
{
    public class BuyerAction
    {
        public static void ShowProductsForSale(Marketplaces marketplace)
        {
            Console.Clear();
            Console.WriteLine("Dostupni proizvodi");
            Console.WriteLine("\nnaziv - cijena - opis");

            var products = ProductRepository.ProductsForSale(marketplace);

            foreach (var product in products)
            {
                Console.WriteLine($"{product.Name} - {product.Price} - {product.Description}");
            }
            Console.WriteLine("\nUnesi enter za nastavak");
            Console.ReadLine();
        }

        public static void BuyProduct(Marketplaces marketplace, Guid BuyerId)
        {
            Console.Clear();
            Console.WriteLine("Kupi proizvod");
            PrintProductId(marketplace);

            Console.Write("\nUnesi id proizvoda koji zelite kupiti: ");
            var productId = Reader.StringInput();

            var Targetproduct = marketplace.Products.FirstOrDefault(product => product.Id.ToString() == productId);

            if (Targetproduct == null)
            {
                Console.WriteLine("Proizvod ne postoji");
                Console.WriteLine("\nStisni enter za povratak");
                Console.ReadLine();
                return;
            }

            float discount = 0;
            Console.Write("Imete li kupone (y/n): ");
            if (Reader.YNanswer())
            {
                Console.Write("Unesite kod kupona: ");
                var CuponeCode = Console.ReadLine();
                if (!string.IsNullOrEmpty(CuponeCode))
                {
                    discount = CuponsRepository.GetDiscount(marketplace, CuponeCode, Targetproduct.Category) / 100;
                }
                if (discount == 0)
                {
                    Console.WriteLine("Neispravan kupon ili ne odgovara kategoriji proizvoda");
                }
                else
                {
                    Console.WriteLine($"Kupon od {discount * 100}% je primjenjen");
                }
            }

            Console.Write($"Jeste li sigurni da zelite kupiti {Targetproduct.Name} (y/n): ");
            if (Reader.YNanswer())
            {
                TransactionRepository.BuyProduct(marketplace, BuyerId, Targetproduct, discount);
            }

            Console.WriteLine("\nStisni enter za povratak");
            Console.ReadLine();
        }

        private static void PrintProductId(Marketplaces marketplace)
        {
            var products = marketplace.Products.Where(product => product.IsSold == false).ToList();

            foreach (var product in products)
            {
                Console.WriteLine($"{product.Id} - {product.Name} - {product.Price} - {product.Description}");
            }
        }

        public static void ReturnProduct(Marketplaces marketplace, Guid buyerId)
        {
            Console.Clear();
            Console.WriteLine("Vrati proizvod");

            var boughtProductsId = marketplace.Transactions
                .Where(transaction => transaction.BuyerId == buyerId)
                .Select(transaction => transaction.ProductId)
                .ToList();

            var boughtProducts = marketplace.Products
                .Where(product => boughtProductsId.Contains(product.Id) && product.IsSold == true)
                .ToList();

            Console.WriteLine("\nId - Naziv - Opis");
            foreach (var product in boughtProducts)
            {
                Console.WriteLine($"{product.Id} - {product.Name} - {product.Description}");
            }

            Console.Write("\nUnesi id proizvoda koji zelite vratiti: ");
            var productId = Reader.StringInput();

            var productToReturn = marketplace.Products.FirstOrDefault(product => product.Id.ToString() == productId);

            if (productToReturn == null)
            {
                Console.WriteLine("Proizvod ne postoji");
                Console.WriteLine("\nStisni enter za povratak");
                Console.ReadLine();
                return;
            }

            Console.Write($"Jeste li sigurni da zelite vratiti proizvod {productToReturn.Name} (y/n): ");
            if (Reader.YNanswer())
            {
                TransactionRepository.ReturnItem(marketplace, buyerId, productToReturn.Id);
                Console.WriteLine("Proizvod uspjesno vracen");
            }

        }
        public static void ShowBoughtProducts(Marketplaces marketplace, Guid buyerId)
        {
            Console.Clear();
            Console.WriteLine("Povijest kupljenih proizvoda");
            Console.WriteLine("\nNaziv - Opis");

            var boughtProductsId = marketplace.Transactions
                .Where(transaction => transaction.BuyerId == buyerId)
                .Select(transaction => transaction.ProductId)
                .ToList();

            var boughtProducts = marketplace.Products
                .Where(product => boughtProductsId.Contains(product.Id))
                .ToList();

            foreach (var product in boughtProducts)
            {
                Console.WriteLine($"{product.Name} - {product.Description}");
            }

            Console.WriteLine("\nStisni enter za povratak");
            Console.ReadLine();
        }

        public static void AddFavProduct(Marketplaces marketplace, Guid buyerId)
        {
            Console.Clear();
            Console.WriteLine("Dodavanje proizvoda u listu omiljenih");
            PrintProductId(marketplace);

            Console.Write("\nUnesi id proizvoda koji zelite dodati u listu omiljenih: ");
            var productId = Reader.StringInput();

            var FavProduct = marketplace.Products.FirstOrDefault(product => product.Id.ToString() == productId);

            if(FavProduct == null)
            {
                Console.WriteLine("Proizvod ne postoji");
                Console.WriteLine("\nStisni enter za povratak");
                Console.ReadLine();
                return;
            }

            Console.Write($"Jeste li sigurni da zelite dodati {FavProduct.Name} u listu omiljenih (y/n): ");
            if (!Reader.YNanswer())
            {
                Console.WriteLine("Proizvod nije dodan u listu omiljenih");
                Console.WriteLine("\nStisni enter za povratak");
                Console.ReadLine();
                return;
            }

            var buyer = marketplace.Buyers.FirstOrDefault(buyers => buyers.Id == buyerId);

            buyer.FavProducts.Add(FavProduct);
        }

        public static void ShowFavProducts(Marketplaces marketplace, Guid buyerId)
        {
            Console.Clear();
            Console.WriteLine("Lista omiljenih proizvoda");
            Console.WriteLine("\nNaziv - Opis");

            var favProducts = marketplace.Buyers.FirstOrDefault(buyer => buyer.Id == buyerId).FavProducts.ToList();

            foreach (var product in favProducts)
            {
                Console.WriteLine($"{product.Name} - {product.Description}");
            }

            Console.WriteLine("\nStisni enter za povratak");
            Console.ReadLine();
        }
    }
}
