using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Repository.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task Create(T entity);
        Task Delete(int id);
        Task<T?> GetById(int id);
        Task<IEnumerable<T>> GetValues();
        Task Update(T entity);
    }
}