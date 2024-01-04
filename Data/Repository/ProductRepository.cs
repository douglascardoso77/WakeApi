
using Data.Context;
using Domain.Dtos.Product;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class ProductRepository : BaseRepository<ProductEntity>, IProductRepository
    {
        public readonly MyContext _mycontext;
        private DbSet<ProductEntity> _dataset;
        public ProductRepository(MyContext context) : base (context)
        {
            _mycontext = context;
            _dataset = _mycontext.Set<ProductEntity>();
        }

        public async Task<IEnumerable<ProductEntity>> GetByName (string name)
        {
             try
            {
                return await _dataset.Where(p=> EF.Functions.Like(p.Name, $"{name}%")).ToListAsync();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        
        public async Task<IEnumerable<ProductEntity>>GetProductsOrderedByColumn(string column)
        {
             try
            {
                return await _dataset.OrderBy(p => EF.Property<object>(p, column)).ToListAsync();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}