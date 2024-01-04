using System;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T:BaseEntity
    {
        Task<T>InsertAsync(T item);
        Task<T>UpdateAsync(T item);
        Task<bool>DeleteAsync(Guid id);
        Task<T>SelectAsync(Guid id);
        Task<IEnumerable<T>>SelectAllAsync();
    }
}