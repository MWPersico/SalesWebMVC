namespace SalesWebMVC.Services.Interfaces
{
    // Interface generica, como parâmetros de tipo uma entidade e tipo de chave primária
    public interface IGenericService<TEntity, TKey> where TEntity : class
    {
        public Task<IList<TEntity>> FindAll();
        public Task<TEntity> Find(TKey key);
        public Task Create(TEntity entity);
        public Task Update(TKey key, TEntity entity);
        public Task Delete(TKey key);
        public bool EntityExists(TKey key);
    }
}
