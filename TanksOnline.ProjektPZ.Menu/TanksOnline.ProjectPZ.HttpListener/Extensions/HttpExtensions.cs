using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TanksOnline.ProjectPZ.HttpListener.Extensions
{
    public static class HttpExtensions
    {
        public static async Task<HttpResponseMessage> PostAsJsonAsync<TModel>(this HttpClient client, string requestUrl, TModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            return await client.PostAsync(requestUrl, stringContent);
        }

        public static async Task<TModel> ReadAsAsync<TModel>(this HttpContent client)
        {
            var model = await client.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TModel>(model);
        }
    }
}
