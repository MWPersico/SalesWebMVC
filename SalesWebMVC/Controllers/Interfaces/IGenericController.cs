using Microsoft.AspNetCore.Mvc;

namespace SalesWebMVC.Controllers.Interfaces
{
    public interface IGenericController<TEntity, TKey> where TEntity : class
    {
        public Task<IActionResult> Index();
        public Task<IActionResult> Details(TKey key);
        public IActionResult Create();
        public Task<IActionResult> Create(TEntity entity);
        public Task<IActionResult> Edit(TKey key);
        public  Task<IActionResult> Edit(TKey key, TEntity entity);
        public Task<IActionResult> Delete(TKey key);
        public Task<IActionResult> DeleteConfirmed(TKey id);
    }
}
