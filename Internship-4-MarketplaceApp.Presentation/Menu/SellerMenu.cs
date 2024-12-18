﻿using Internship_4_MarketplaceApp.Data.Entities;
using Internship_4_MarketplaceApp.Domain.Repositorioes;
using Internship_4_MarketplaceApp.Presentation.Actions;
using Internship_4_MarketplaceApp.Presentation.Helpers;
using System;
using System.Linq;

namespace Internship_4_MarketplaceApp.Presentation.Menu
{
    public class SellerMenu
    {
        public static void DisplaySellerMenu(Marketplaces marketplace, string email)
        {
            Guid sellerId = SellerRepository.FindSellerGuid(marketplace, email);
            int option = 0;
            do
            {
                Console.Clear();
                Console.WriteLine($"Prodavač zarada {marketplace.Sellers.FirstOrDefault(seller => seller.Id == sellerId).Earned}");
                Console.WriteLine("1. Dodaj proizvod\n2. Pregled svih proizvoda u vlasništvu prodavača\n3. Pregled prodanih proizvoda po kategoriji\n4. Pregled zarade u određenom vremenskom razdoblju\n5. Uredi cijenu proizvoda\n6. Odjava");
                option = Reader.NumInput(1, 6);
                switch (option)
                {
                    case 1:
                        SellerActions.AddNewProduct(marketplace, sellerId);
                        break;
                    case 2:
                        SellerActions.ShowSellersProductsForSale(marketplace, sellerId);
                        break;
                    case 3:
                        SellerActions.SoldProductsByCategory(marketplace, sellerId);
                        break;
                    case 4:
                        SellerActions.ProfitInTimeRange(marketplace, sellerId);
                        break;
                    case 5:
                        SellerActions.EditProductPrice(marketplace, sellerId);
                        break;
                    default:
                        break;
                }
            } while (option != 6);
        }
    }
}

