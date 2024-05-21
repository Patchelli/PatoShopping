using PatoShopping.WEB.Models;
using PatoShopping.WEB.Services.IServices;
using PatoShopping.WEB.Utils;

namespace PatoShopping.WEB.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public const string BasePath = "api/product";
        public ProductService()
        {
        }

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ProductModel>> FindByAllProducts()
        {
            var response = await _httpClient.GetAsync(BasePath);

            return await response.ReadContentAs<IEnumerable<ProductModel>>();
        }

        public async Task<ProductModel> FindProductById(long id)
        {
            var response = await _httpClient.GetAsync($"{BasePath}/{id}");

            return await response.ReadContentAs<ProductModel>();
        }
        public async Task<ProductModel> Create(ProductModel model)
        {
            var response = await _httpClient.PostAsJson(BasePath, model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProductModel>();
            else
                throw new Exception("Something went wrog when calling API");
        }

        public async Task<ProductModel> Update(ProductModel model)
        {
            var response = await _httpClient.PutAsJson(BasePath, model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProductModel>();
            else
                throw new Exception("Something went wrog when calling API");
        }

        public async Task<bool> DeleteProductById(long id)
        {
            var response = await _httpClient.GetAsync($"{BasePath}/{id}");
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();
            else
                throw new Exception("Something went wrog when calling API");
        }
    }
}
