using CoreFoundation;
using System;
using System.Net;
using SystemConfiguration;
using XamApp.iOS.Dependencies;
using XamApp.Models.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(ConnectionChecker))]
namespace XamApp.iOS.Dependencies
{
    public class ConnectionChecker : IConnectionChecker
    {
        public bool IsConnected { get; set; }

        public void CheckNetworkConnection()
        {
            IsConnected = GetInternetStatus();
        }

        private bool GetInternetStatus()
        {
            NetworkReachabilityFlags flags;
            bool isNetworkAvailable = IsNetworkAvailable(out flags);

            if (isNetworkAvailable && ((flags & NetworkReachabilityFlags.IsDirect) != 0))
                return false;
            else if ((flags & NetworkReachabilityFlags.IsWWAN) != 0)
                return true;
            else if (flags == 0)
                return false;

            return true;
        }

        private NetworkReachability _defaultReachability;
        private bool IsNetworkAvailable(out NetworkReachabilityFlags flags)
        {
            if (_defaultReachability == null)
            {
                _defaultReachability = new NetworkReachability(new IPAddress(0));
                _defaultReachability.SetNotification(OnChange);
                _defaultReachability.Schedule(CFRunLoop.Current, CFRunLoop.ModeDefault);
            }

            if (!_defaultReachability.TryGetFlags(out flags))
                return false;

            return IsReachableWithoutRequiringConnection(flags);
        }

        private event EventHandler ReachabilityChanged;
        private void OnChange(NetworkReachabilityFlags flags)
        {
            ReachabilityChanged?.Invoke(null, EventArgs.Empty);
        }

        private bool IsReachableWithoutRequiringConnection(NetworkReachabilityFlags flags)
        {
            bool isReachable = (flags & NetworkReachabilityFlags.Reachable) != 0;
            bool noConnectionRequired = (flags & NetworkReachabilityFlags.ConnectionRequired) == 0;

            if ((flags & NetworkReachabilityFlags.IsWWAN) != 0)
                noConnectionRequired = true;

            return isReachable && noConnectionRequired;
        }
    }
}
