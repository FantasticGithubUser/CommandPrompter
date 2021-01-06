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
        public static void AddJWTBearer()
        {
            client.DefaultRequestHeaders.Remove("Authorization");
            if(AccountHolder.Token != null)
                client.DefaultRequestHeaders.Add("Authorization", AccountHolder.Token);
        }

        public static async Task GetAsync<T>(string address, Action<T> callback) where T : class, new()
        {
            var response = await client.GetAsync(address);
            response.EnsureSuccessStatusCode();
            var res = ModelBindingHelper.BindModel<T>(response.Content.ReadAsStringAsync().Result);
            callback.Invoke(res);
        }

        public static async Task PostAsync<T>(string address, string jsonContent, Action<T> callback) where T : class, new()
        {
            var httpContent = new StringContent(jsonContent,Encoding.UTF8,"application/json");
            var response = await client.PostAsync(address, httpContent);
            response.EnsureSuccessStatusCode();
            var res = ModelBindingHelper.BindModel<T>(response.Content.ReadAsStringAsync().Result);
            callback.Invoke(res);
        }

        public static async Task PutAsync<T>(string address, string jsonContent, Action<T> callback) where T : class, new()
        {
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await client.PutAsync(address, httpContent);
            response.EnsureSuccessStatusCode();
            var res = ModelBindingHelper.BindModel<T>(response.Content.ReadAsStringAsync().Result);
            callback.Invoke(res);
        }

        public static async Task DeleteAsync<T>(string address, Action<T> callback) where T : class, new()
        {
            var response = await client.DeleteAsync(address);
            response.EnsureSuccessStatusCode();
            var res = ModelBindingHelper.BindModel<T>(response.Content.ReadAsStringAsync().Result);
            callback.Invoke(res);
        }
        
    }
}
