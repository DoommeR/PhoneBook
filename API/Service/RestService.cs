using API.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace API
{

   
    public class RestService : IRestService
    {
        HttpClient _client;
        private static string url = "https://randomuser.me/api";


        public RestService()
        {
            _client = new HttpClient();
        }

        public Task<string> Get(string uri)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Contact>> RefreshDataAsync()
        {

            var uri = new Uri(string.Format(url, string.Empty));

            var response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                List<Contact> Items = JsonConvert.DeserializeObject<List<Contact>>(content);
                return Items;
            }
            return null;
        }
    }
}
