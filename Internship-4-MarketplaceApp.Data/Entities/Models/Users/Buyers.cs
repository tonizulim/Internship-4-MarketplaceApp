using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_4_MarketplaceApp.Data.Entities.Models.Users
{
    public class Buyers : Users
    {
        public int Saldo { get; set; }

        public Buyers(string name, string email, int saldo) : base(name, email)
        {
            Saldo = saldo;
        }
    }
}
