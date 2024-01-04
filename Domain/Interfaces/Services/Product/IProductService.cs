using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dtos.Product;
using Domain.Entities;

namespace Domain.Interfaces.Services.Product
{
    public interface IProductService
    {
        Task<ProductDto> Get(Guid id);
        Task<IEnumerable<ProductDto>> GetAll();
        Task<ProductUpdatedResult> Update (ProductDtoUpdate product);
        Task<ProductCreateResult> Insert (ProductDtoCreate product);
        Task<bool> Delete (Guid id);
        Task<IEnumerable<ProductDto>> GetByName (string name);
        Task<IEnumerable<ProductDto>>GetProductsOrderedByColumn(string column);
    }
}