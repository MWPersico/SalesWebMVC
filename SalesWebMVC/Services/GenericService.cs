using System.CodeDom;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Data;
using SalesWebMVC.Services.Interfaces;

namespace SalesWebMVC.Services
{
    public abstract class GenericService<TEntity, TKey> : IGenericService<TEntity, TKey> where TEntity : class
    {
        protected readonly SalesWebMVCContext _context;
        public GenericService() { }

        public GenericService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public virtual async Task<IList<TEntity>> FindAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity> Find(TKey key)
        {
            if (!EntityExists(key))
                throw new KeyNotFoundException();

            return await _context.Set<TEntity>().FindAsync(key);
        }

        public virtual async Task Create(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task Delete(TKey key)
        {
            _context.Set<TEntity>().Remove(await Find(key));
            await _context.SaveChangesAsync();
        }

        public virtual bool EntityExists(TKey key)
        {
            return _context.Set<TEntity>().Find(key) != null;
        }
    }
}
