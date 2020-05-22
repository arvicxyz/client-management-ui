using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace XamApp.Views.Custom
{
    public class CustomTabBar : Xamarin.Forms.TabbedPage
    {
        public CustomTabBar()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetBackButtonTitle(this, "");

            BarBackgroundColor = Color.FromHex("#343542");
            SelectedTabColor = Color.FromHex("#FFBA00");
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);

            var clientsPage = new ClientListPage();
            clientsPage.IconImageSource = "ic_clients.png";
            clientsPage.Title = "";

            var inventoryPage = new ContentPage();
            inventoryPage.IconImageSource = "ic_inventory.png";
            inventoryPage.Title = "";

            var messagesPage = new ContentPage();
            messagesPage.IconImageSource = "ic_messages.png";
            messagesPage.Title = "";

            var settingsPage = new ContentPage();
            settingsPage.IconImageSource = "ic_settings.png";
            settingsPage.Title = "";

            Children.Add(clientsPage);
            Children.Add(inventoryPage);
            Children.Add(messagesPage);
            Children.Add(settingsPage);
        }
    }
}
