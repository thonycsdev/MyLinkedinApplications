using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;

namespace Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _entity;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _entity = _dbContext.Set<T>();
        }

        public async Task Create(T entity)
        {
            entity.CreatedAt = DateTime.Now.ToUniversalTime();
            entity.UpdatedAt = DateTime.Now.ToUniversalTime();
            _entity.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await FindEntityOrThrow(id);
            _entity.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T?> GetById(int id)
        {
            var entity = await FindEntityOrThrow(id);
            return entity;
        }

        public async Task<IEnumerable<T>> GetValues()
        {
            return await _entity.ToListAsync();
        }


        public async Task Update(T entity)
        {
            entity.UpdatedAt = DateTime.Now.ToUniversalTime();
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
        private async Task<T> FindEntityOrThrow(int id)
        {
            return await _entity.Where(x => x.Id == id).FirstOrDefaultAsync() ?? throw new IndexOutOfRangeException("User not found");
        }
    }
}