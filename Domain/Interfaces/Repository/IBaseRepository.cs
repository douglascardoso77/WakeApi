using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity 
    {
        Task<bool> DeleteAsync(Guid id);
        Task<T> InsertAsync(T item);
        Task<IEnumerable<T>> SelectAllAsync();
        Task<T> SelectAsync(Guid id);
        Task<T> UpdateAsync(T item);
    }
}