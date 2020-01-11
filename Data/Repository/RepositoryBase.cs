using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Library.Data.Repository
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DataContext Context;
        protected readonly DbSet<TEntity> DbSet;

        protected RepositoryBase(DataContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> List()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<TEntity> Get(object id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<TEntity> Create(TEntity entity)
        {
            var entityToStore = DbSet.Add(entity).Entity;

            await Context.SaveChangesAsync();
            return entityToStore;
        }
        
        public virtual async Task<bool> StoreMany(ICollection<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                var addEntity = DbSet.Add(entity).Entity;
            }
            
            return await Context.SaveChangesAsync() > 0;
        }

        public virtual async Task<bool> Update(TEntity entityToUpdate)
        {
            DbSet.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;

            return await Context.SaveChangesAsync() > 0;
        }

        public virtual async Task<bool> Remove(int id)
        {
            var entityToRemove = await DbSet.FindAsync(id);
            Context.Remove(entityToRemove);

            return await Context.SaveChangesAsync() > 0;
        }
    }
}