using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatoShopping.API.Data.ValueObjects;
using PatoShopping.API.Model;
using PatoShopping.API.Model.Context;
using PatoShopping.API.Repository.Interface;

namespace PatoShopping.API.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbContextApp _contextApp;
        private IMapper _mapper;

        public ProductRepository(DbContextApp dbContext, IMapper mapper)
        {
            _contextApp = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductVO>> GetAll()
        {
            List<Product> products = await _contextApp.Products.ToListAsync();
            return _mapper.Map<List<ProductVO>>(products);
        }

        public async Task<ProductVO> FindById(long id)
        {
            Product product = await _contextApp.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<ProductVO>(product);
        }

        public async Task<ProductVO> Create(ProductVO productVo)
        {
            Product product = _mapper.Map<Product>(productVo);
            _contextApp.Products.Add(product);
            await _contextApp.SaveChangesAsync();

            return _mapper.Map<ProductVO>(product);
        }

        public async Task<ProductVO> Update(ProductVO productVo)
        {
            Product product = _mapper.Map<Product>(productVo);
            _contextApp.Products.Update(product);
            await _contextApp.SaveChangesAsync();

            return _mapper.Map<ProductVO>(product);
        }

        public async Task<bool> DeleteById(long id)
        {
            try
            {
                Product product = await _contextApp.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (product != null) return false;

                _contextApp.Products.Remove(product);
                await _contextApp.SaveChangesAsync(true);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
