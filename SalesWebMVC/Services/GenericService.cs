using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Data;
using SalesWebMVC.Services.Interfaces;

namespace SalesWebMVC.Services
{
    public abstract class GenericService<TEntity, TKey>(SalesWebMVCContext context) : IGenericService<TEntity, TKey>
        where TEntity : class
    {
        protected readonly SalesWebMVCContext Context = context;

        public virtual async Task<IList<TEntity>> FindAll()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity> Find(TKey? key)
        {
            if (!EntityExists(key))
                throw new KeyNotFoundException();

            return await Context.Set<TEntity>().FindAsync(key);
        }

        public virtual async Task Create(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public virtual async Task Update(TKey key, TEntity entity)
        {
            Context.Entry(await Find(key)).CurrentValues.SetValues(entity);
            await Context.SaveChangesAsync();
        }

        public virtual async Task Delete(TKey key)
        {
            Context.Set<TEntity>().Remove(await Find(key));
            await Context.SaveChangesAsync();
        }

        public virtual bool EntityExists(TKey key)
        {
            return Context.Set<TEntity>().Find(key) != null;
        }
    }
}
