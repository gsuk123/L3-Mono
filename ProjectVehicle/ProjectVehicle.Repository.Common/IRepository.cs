using ProjectVehicle.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVehicle.Repository.Common
{
    public interface IRepository<TEntity> where TEntity : class //Generic interface where T entity is a class
    {

        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetIdAsync(int id);
        Task<int> DeleteAsync(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity updated, int id);

    }
}
