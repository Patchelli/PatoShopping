using PatoShopping.API.Data.ValueObjects;

namespace PatoShopping.API.Repository.Interface
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductVO>> GetAll();
        Task<ProductVO> FindById(long id);
        Task<ProductVO> Create(ProductVO product);
        Task<ProductVO> Update(ProductVO product);
        Task<bool> DeleteById(long id);
    }
}
