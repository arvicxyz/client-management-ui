using XamApp.Models.Interfaces;
using Xamarin.Forms;

namespace XamApp.Utilities
{
    public static class AppGlobal
    {
        public static bool IsOnline
        {
            get
            {
                var connectionChecker = DependencyService.Get<IConnectionChecker>();
                connectionChecker.CheckNetworkConnection();
                return connectionChecker.IsConnected;
            }
        }
    }
}
