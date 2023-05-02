using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;

namespace inFlow.Api.Examples
{
    class Program
    {
        private static readonly string _apiVersion = "2021-04-26";
        private static readonly string _apiKey = "";
        private static readonly string _companyId = "";
        private static readonly HttpClient _client = new HttpClient();
        private static readonly string _baseUrl = $"https://cloudapi.inflowinventory.com/{_companyId}/products";

        static async Task Main(string[] args)
        {
            // Intitialize HttpClient with correct headers to call inFLow API (https://cloudapi.inflowinventory.com/docs/index.html)
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Add("User-Agent", "C# console app");
            _client.DefaultRequestHeaders.Accept.ParseAdd($"application/json;version={_apiVersion}");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);

            var productId = Guid.NewGuid();
            await CreateProduct(productId);
            await GetProduct(productId);
            await UpdateProduct(productId);
            await CreateProducts(new List<Guid>() { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() });
        }

        static async Task GetProduct(Guid productId)
        {
            Console.WriteLine("GetProduct");

            var url = $"{_baseUrl}/{productId}";
            var response = await _client.GetAsync(url);

            Console.WriteLine(response);
        }

        static async Task CreateProduct(Guid productId)
        {
            Console.WriteLine("CreateProduct");

            var product = new { ProductId = productId, ItemType = "StockedProduct", TrackSerials = false, Name = productId.ToString() };
            var serialized = JsonSerializer.Serialize(product);
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync(_baseUrl, stringContent);

            Console.WriteLine(response);
        }

        static async Task CreateProducts(List<Guid> productIds)
        {
            Console.WriteLine("CreateProducts");
            var products = productIds.Select(productId => new { ProductId = productId, ItemType = "StockedProduct", TrackSerials = false, Name = productId.ToString() }).ToList();
            var serialized = JsonSerializer.Serialize(products);
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");
            Console.WriteLine(serialized);
            var response = await _client.PutAsync(_baseUrl, stringContent);

            Console.WriteLine(response);
        }

        static async Task UpdateProduct(Guid productId)
        {
            Console.WriteLine("UpdateProduct");

            var product = new { ProductId = productId, Descripton = "Blah" };
            var serialized = JsonSerializer.Serialize(product);
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync(_baseUrl, stringContent);

            Console.WriteLine(response);
        }
    }
}
