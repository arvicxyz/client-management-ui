using XamApp.Models.Constants;

namespace XamApp.RestClient
{
    public class ApiClient
    {
        protected string BaseUrl { get; private set; }

        protected string Controller { get; set; }

        public ApiClient()
        {
            BaseUrl = $"{ApiSettings.SCHEME}://{ApiSettings.HOST}/{ApiSettings.ROOT}";
        }
    }
}
