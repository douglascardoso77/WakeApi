using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IProductRepository : IRepository<ProductEntity>
    {
        Task<IEnumerable<ProductEntity>> GetByName (string name);
        Task<IEnumerable<ProductEntity>>GetProductsOrderedByColumn(string column);
    }
}