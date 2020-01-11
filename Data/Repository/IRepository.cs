using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Library.Data.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> List();
        Task<TEntity> Get(object id);
        Task<TEntity> Create(TEntity entity);
        Task<bool> StoreMany(ICollection<TEntity> entities);
        Task<bool> Update(TEntity entityToUpdate);
        Task<bool> Remove(int id);
    }
}