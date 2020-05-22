using ModernHttpClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace XamApp.RestClient
{
    public static class RestClientService
    {
        private static readonly HttpClient _client = new HttpClient(new NativeMessageHandler());

        public static async Task<string> ExecuteSimpleGetRequestAsync(string request)
        {
            string json = null;

            try
            {
                var response = await _client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    json = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception e)
            {
                e.ToString();
            }

            return json;
        }

        public static async Task<string> ExecuteSimplePostRequestAsync(string request, Dictionary<string, string> parameter)
        {
            string json = null;

            try
            {
                var content = new FormUrlEncodedContent(parameter);
                var response = await _client.PostAsync(request, content);
                if (response.IsSuccessStatusCode)
                {
                    json = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception e)
            {
                e.ToString();
            }

            return json;
        }

        public static async Task<string> ExecuteGetRequestAsync(string resource)
        {
            string json = null;

            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, new Uri(resource));
                var response = await _client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    json = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception e)
            {
                e.ToString();
            }

            return json;
        }

        public static async Task<string> ExecutePostRequestAsync(string resource, object item)
        {
            string json = null;

            try
            {
                var data = JsonConvert.SerializeObject(item);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage(HttpMethod.Post, new Uri(resource))
                {
                    Content = content
                };
                var response = await _client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    json = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception e)
            {
                e.ToString();
            }

            return json;
        }

        public static async Task<string> ExecuteGetRequestAsync(HttpRequestMessage request)
        {
            string json = null;

            try
            {
                var response = await _client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    json = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception e)
            {
                e.ToString();
            }

            return json;
        }

        public static async Task<string> ExecutePostRequestAsync(HttpRequestMessage request)
        {
            string json = null;

            try
            {
                var response = await _client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    json = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception e)
            {
                e.ToString();
            }

            return json;
        }

        public static void CancelPendingRequests()
        {
            _client.CancelPendingRequests();
        }
    }
}
