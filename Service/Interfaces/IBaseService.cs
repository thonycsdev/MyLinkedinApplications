using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IBaseService<TEntityResponse, TEntityRequest>
    {
        Task<TEntityResponse> GetByIdAsync(int id);
        Task<IEnumerable<TEntityResponse>> GetAllAsync();
        Task<TEntityResponse> CreateAsync(TEntityRequest entity);
        Task<TEntityResponse> UpdateAsync(TEntityRequest entity);
        Task DeleteAsync(int id);
    }
}
