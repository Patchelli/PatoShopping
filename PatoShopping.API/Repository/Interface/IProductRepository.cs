using PatoShopping.API.Data.ValueObjects;

namespace PatoShopping.API.Repository.Interface
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductVO>> GetAll();
        Task<IEnumerable<ProductVO>> FindById(long id);
        Task<IEnumerable<ProductVO>> Create(ProductVO product);
        Task<IEnumerable<ProductVO>> Update(ProductVO product);
        Task<IEnumerable<ProductVO>> DeleteById(long id);
    }
}
