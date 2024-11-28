using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_4_MarketplaceApp.Data.Entities.Models.Users
{
    public class Buyers : Users
    {
        public float Saldo { get; set; }
        public List<Products> FavProducts { get; set; }

        public Buyers(string name, string email, float saldo) : base(name, email)
        {
            Saldo = saldo;
            FavProducts = new List<Products>();
        }
    }
}
