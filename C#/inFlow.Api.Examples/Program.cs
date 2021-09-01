using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace inFlow.Api.Examples
{
    class Program
    {
        private static readonly string _apiVersion = "2021-04-26";
        private static readonly string _apiKey = "";
        private static readonly string _companyId = "";
        private static readonly HttpClient _client = new HttpClient();

        static async Task Main(string[] args)
        {
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Add("User-Agent", "C# console app");
            _client.DefaultRequestHeaders.Accept.ParseAdd($"application/json;version={_apiVersion}");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);

            var url = $"https://cloudapi.inflowinventory.com/{_companyId}/sales-orders";
            var response = await _client.GetAsync(url);
            Console.WriteLine(response);
        }
    }
}
