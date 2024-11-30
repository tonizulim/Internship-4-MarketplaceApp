using Internship_4_MarketplaceApp.Data.Entities.Models.Enums;
using Internship_4_MarketplaceApp.Data.Entities.Models.Users;
using Internship_4_MarketplaceApp.Data.Entities.Models;
using System;
using System.Collections.Generic;

namespace Internship_4_MarketplaceApp.Data.Seeds
{
    internal class DatabaseSeeder
    {
        public static readonly List<Sellers> Sellers = new List<Sellers>
            {
                new Sellers("k", "k@k.k"),
                new Sellers("marko", "marko@m.m"),
                new Sellers("petar", "petar@p.p")
            };

        public static readonly List<Buyers> Buyers = new List<Buyers>
            {
                new Buyers("luka", "luka@l.l", 1000),
                new Buyers("luk", "luk@l.l", 100),
                new Buyers("martko", "martko@m.m", 100)
            };
        
        
        public static readonly List<Products> Products = new List<Products>{
            new Products("Laptop", "Dell", 5000, Sellers[0].Id, Category.Elektronika, true),
            new Products("Knjiga", "Harry Potter", 100, Sellers[0].Id, Category.Knjige, true),
            new Products("Majica", "Nike", 50, Sellers[0].Id, Category.Odjeća),
            new Products("Laptop", "Asus", 800, Sellers[1].Id, Category.Elektronika, true),
            new Products("Knjiga", "Hobbit", 120, Sellers[1].Id, Category.Knjige),
            new Products("Majica", "Adidas", 55, Sellers[1].Id, Category.Odjeća, true),
            new Products("Televizor", "Samsung", 300, Sellers[1].Id, Category.Elektronika, true),
            new Products("Mobitel", "iPhone 13", 700, Sellers[1].Id, Category.Elektronika),
            new Products("Knjiga", "Game of Thrones", 150, Sellers[0].Id, Category.Knjige),
            new Products("Hlače", "Levi's", 200, Sellers[0].Id, Category.Odjeća, true),
            new Products("Laptop", "HP Pavilion", 450, Sellers[1].Id, Category.Elektronika),
            new Products("Monitor", "LG UltraWide", 200, Sellers[2].Id, Category.Elektronika, true),
            new Products("Knjiga", "The Catcher in the Rye", 80, Sellers[0].Id, Category.Knjige),
            new Products("Majica", "Puma", 60, Sellers[0].Id, Category.Odjeća, true),
            new Products("Televizor", "Sony Bravia", 300, Sellers[0].Id, Category.Elektronika),
            new Products("Mobitel", "Samsung Galaxy S22", 60, Sellers[1].Id, Category.Elektronika),
            new Products("Torba", "Herschel", 300, Sellers[0].Id, Category.Odjeća, true),
            new Products("Knjiga", "The Lord of the Rings", 20, Sellers[2].Id, Category.Knjige),
            new Products("Slušalice", "Bose QC 35", 150, Sellers[1].Id, Category.Elektronika, true),
            new Products("Jakna", "North Face", 50, Sellers[0].Id, Category.Odjeća, true),

        };

        public static readonly List<Transaction> Transactions = new List<Transaction>
        {
            new Transaction(Buyers[0].Id, Sellers[0].Id, Products[0].Id, 5000, DateTime.Parse("2023-10-11")),
            new Transaction(Buyers[0].Id, Sellers[0].Id, Products[1].Id, 100, DateTime.Parse("2021-10-11")),
            new Transaction(Buyers[0].Id, Sellers[0].Id, Products[2].Id, 50, DateTime.Parse("2022-10-11"))

        };

        public static readonly List<Cupons> Cupons = new List<Cupons>
        {
            new Cupons("bozic", 10, DateTime.Parse("31-12-2024"), Category.Elektronika),
            new Cupons("petak", 50, DateTime.Parse("01-12-2024"), Category.Knjige)
            
        };



    }
}
