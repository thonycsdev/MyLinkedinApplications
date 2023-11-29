using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            _entity.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public Task Delete(int id)
        {
            var entity = _entity.Where(x => x.Id == id).FirstOrDefault() ?? throw new IndexOutOfRangeException();
            _entity.Remove(entity);
            return _dbContext.SaveChangesAsync();
        }

        public async Task<T?> GetById(int id)
        {
            var entity = await _entity.Where(x => x.Id == id).FirstOrDefaultAsync() ?? throw new IndexOutOfRangeException();
            return entity;
        }

        public async Task Update(T entity)
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}