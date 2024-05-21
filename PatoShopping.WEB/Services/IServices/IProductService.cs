using PatoShopping.WEB.Models;

namespace PatoShopping.WEB.Services.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> FindByAllProducts();
        Task<ProductModel> FindProductById(long id);
        Task<ProductModel> Create(ProductModel model);
        Task<ProductModel> Update(ProductModel model);
        Task<bool> DeleteProductById(long id);
    }
}
