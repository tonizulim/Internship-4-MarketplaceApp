
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
