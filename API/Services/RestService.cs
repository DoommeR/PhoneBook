using API.Interfaces;
using API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.Services
{

   
    public class RestService : IRestService
    {
        HttpClient _client;
        private static string url = "https://randomuser.me/api";
        public List<Contact> Items { get; private set; }

        public RestService()
        {
            _client = new HttpClient();
        }


        public async Task<List<Contact>> RefreshDataAsync()
        {
            Items = new List<Contact>();
            var uri = new Uri(string.Format(url, string.Empty));
            try {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<List<Contact>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return Items;
        }
    }
}
