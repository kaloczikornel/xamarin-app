using IceAndFire.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IceAndFire.Services
{
    public class IceAndFireService
    {
        private async Task<T> GetAsync<T>(Uri uri)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                var json = await response.Content.ReadAsStringAsync();
                T result = JsonConvert.DeserializeObject<T>(json);
                return result;
            }
        }

        private readonly Uri serverUrl = new Uri("https://www.anapioficeandfire.com");
        public async Task<List<Book>> GetBooksAsync()
        {
            return await GetAsync<List<Book>>(new Uri(serverUrl, "api/books"));
        }
        public async Task<Book> GetBookAsync(string uri)
        {
            return await GetAsync<Book>(new Uri(uri));
        }
        public async Task<List<Character>> GetCharactersAsync()
        {
            return await GetAsync<List<Character>>(new Uri(serverUrl, "api/characters"));
        }
        public async Task<Character> GetCharacterAsync(string uri)
        {
            return await GetAsync<Character>(new Uri(uri));
        }
        public async Task<List<House>> GetHousesAsync()
        {
            return await GetAsync<List<House>>(new Uri(serverUrl, "api/houses"));
        }
        public async Task<House> GetHouseAsync(string uri)
        {
            return await GetAsync<House>(new Uri(uri));
        }
        public async Task<List<Book>> GetBookByNameQueryString(string str)
        {
            string query = "";
            if (str != null)
            {
                string[] subs = str.Split(' ');
                query = string.Join("%20", subs);
            }
            return await GetAsync<List<Book>>(new Uri(serverUrl, $"api/books/?name={query}"));
        }
        public async Task<List<House>> GetHouseByNameQueryString(string str)
        {
            string query = "";
            if (str != null)
            {
                string[] subs = str.Split(' ');
                query = string.Join("%20", subs);
            }
            return await GetAsync<List<House>>(new Uri(serverUrl, $"api/houses/?name={query}"));
        }
        public async Task<List<Character>> GetCharacterByNameQueryString(string str)
        {
            string query = "";
            if (str != null)
            {
                string[] subs = str.Split(' ');
                query = string.Join("%20", subs);
            }
            return await GetAsync<List<Character>>(new Uri(serverUrl, $"api/characters/?name={query}"));
        }
        public string StringArrayToString(string[] str)
        {
            return str.Length == 0 ? "No data" : string.Join("\n", str);
        }
    }
}

