namespace XamApp.Models.Interfaces
{
    public interface IConnectionChecker
    {
        bool IsConnected { get; }

        void CheckNetworkConnection();
    }
}
