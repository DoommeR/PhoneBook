﻿using API.Interfaces;
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
        private bool _isOnline = false;
        HttpClient _client;
        private static string url = "https://randomuser.me/api/?inc=name,phone&noinfo&results=10";
        public Result Items { get; private set; }

        public RestService()
        {
            _client = new HttpClient();
        }


        public async Task<Result> RefreshDataAsync()
        {
            Items = new Result();
            var uri = new Uri(string.Format(url, string.Empty));
            try {

                if (_isOnline) {
                    var response = await _client.GetAsync(uri);
                    
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        Items = JsonConvert.DeserializeObject<Result>(content);
                    }
                }
                else {

                    string content = "{ \"results\":[{\"name\":{\"title\":\"Mrs\",\"first\":\"Ömür\",\"last\":\"Fahri\"},\"phone\":\"(283)-286-7321\"},{\"name\":{\"title\":\"Ms\",\"first\":\"Laura\",\"last\":\"Andersen\"},\"phone\":\"50035009\"}]}";
                    Items = JsonConvert.DeserializeObject<Result>(content);
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
