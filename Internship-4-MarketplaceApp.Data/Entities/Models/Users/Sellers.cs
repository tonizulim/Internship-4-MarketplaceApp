using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_4_MarketplaceApp.Data.Entities.Models.Users
{
    public class Sellers : Users
    {
        public float Earned { get; set; }
        public Sellers(string name, string email) : base(name, email)
        {
            Earned = 0;
        }

    }
}
