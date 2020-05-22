using Android.Content;
using Android.Net;
using XamApp.Droid.Dependencies;
using XamApp.Models.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(ConnectionChecker))]
namespace XamApp.Droid.Dependencies
{
    public class ConnectionChecker : IConnectionChecker
    {
        public bool IsConnected { get; set; }

        public void CheckNetworkConnection()
        {
            var connectivityManager = (ConnectivityManager)Android.App.Application.Context
                .ApplicationContext.GetSystemService(Context.ConnectivityService);
            var activeNetworkInfo = connectivityManager.ActiveNetworkInfo;
            if (activeNetworkInfo != null && activeNetworkInfo.IsConnected)
                IsConnected = true;
            else
                IsConnected = false;
        }
    }
}
