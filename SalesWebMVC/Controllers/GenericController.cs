using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Controllers.Interfaces;
using SalesWebMVC.Services.Interfaces;

namespace SalesWebMVC.Controllers
{
    public abstract class GenericController<TEntity, TKey> : Controller, IGenericController<TEntity, TKey>
        where TEntity : class
    {
        protected readonly IGenericService<TEntity, TKey> Service;

        protected GenericController(IGenericService<TEntity, TKey> service)
        {
            Service = service;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public abstract Task<IActionResult> Create(TEntity entity);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public abstract Task<IActionResult> Edit(TKey id, TEntity entity);

        public async Task<IActionResult> Index()
        {
            return View(await Service.FindAll());
        }

        public async Task<IActionResult> Details(TKey id)
        {
            if (!Service.EntityExists(id))
                return NotFound();

            TEntity entity = await Service.Find(id);
            return View(entity);
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Edit(TKey id)
        {
            if (!Service.EntityExists(id))
                return NotFound();

            TEntity entity = await Service.Find(id);
            return View(entity);
        }

        public async Task<IActionResult> Delete(TKey id)
        {
            if (!Service.EntityExists(id))
                return NotFound();

            TEntity entity = await Service.Find(id);
            return View(entity);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(TKey id)
        {
            if (!Service.EntityExists(id))
                return NotFound();

            await Service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
