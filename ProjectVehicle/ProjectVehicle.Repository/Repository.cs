using ProjectVehicle.DAL;
using ProjectVehicle.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Validation;
using ProjectVehicle.DAL.Entities;
using System.Linq.Expressions;

namespace ProjectVehicle.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context; 

        public Repository(DbContext context)
        {
            Context = context;
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }
        public async Task<TEntity> GetIdAsync(int id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity updated, int id)
        {
            if (updated == null)
                return null;
            TEntity existing = await Context.Set<TEntity>().FindAsync(id);
            if (existing != null)
            {
                Context.Entry(existing).CurrentValues.SetValues(updated);
                await Context.SaveChangesAsync();
            }
            return existing;
        }
        public async Task<int> DeleteAsync(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            return await Context.SaveChangesAsync();
        }

    }
}
