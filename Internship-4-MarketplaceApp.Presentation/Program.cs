using Internship_4_MarketplaceApp.Data.Entities;
using Internship_4_MarketplaceApp.Presentation.Actions;
using Internship_4_MarketplaceApp.Presentation.Menu;

namespace Internship_4_MarketplaceApp.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
        Marketplaces marketplace = new Marketplaces();

        MainMenu.DisplayMainMenu(marketplace);
        }
    }
}
