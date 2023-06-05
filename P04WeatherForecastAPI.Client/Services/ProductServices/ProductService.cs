using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using P06Shop.Shared;
using P06Shop.Shared.Services.ProductService;
using P06Shop.Shared.Shop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.Services.ProductServices
{
    internal class ProductService : IProductService
    {
        public ProductService()
        {
            var builder = new ConfigurationBuilder()
               .AddUserSecrets<App>()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsetings.json");


        }

        public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7230/api/Product");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
             
            var json = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ServiceResponse<List<Product>>>(json);

            return result;
        }
    }
}
