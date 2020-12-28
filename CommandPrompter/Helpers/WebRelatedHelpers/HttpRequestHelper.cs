using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CommandPrompter.Helpers
{
    public static class HttpRequestHelper
    {
        private static readonly HttpClient client = new HttpClient();
        private static void AddJWTBearer()
        {
            client.DefaultRequestHeaders.Add("Authorization", AccountHolder.Token);
        }

        public static async Task<T> GetAsync<T>(string address) where T : class, new()
        {
            var response = await client.GetAsync(address);
            response.EnsureSuccessStatusCode();
            return ModelBindingHelper.BindModel<T>(response.Content.ReadAsStringAsync().Result);
        }

        public static async Task<T> PostAsync<T>(string address, string jsonContent) where T : class, new()
        {
            var httpContent = new StringContent(jsonContent);
            var response = await client.PostAsync(address, httpContent);
            return ModelBindingHelper.BindModel<T>(response.Content.ReadAsStringAsync().Result);
        }

        public static async Task<T> PutAsync<T>(string address, string jsonContent) where T : class, new()
        {
            var httpContent = new StringContent(jsonContent);
            var response = await client.PutAsync(address, httpContent);
            return ModelBindingHelper.BindModel<T>(response.Content.ReadAsStringAsync().Result);
        }

        public static async Task<T> DeleteAsync<T>(string address) where T : class, new()
        {
            var response = await client.DeleteAsync(address);
            return ModelBindingHelper.BindModel<T>(response.Content.ReadAsStringAsync().Result);
        }
        
    }
}
