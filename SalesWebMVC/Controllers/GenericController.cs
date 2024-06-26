﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Controllers.Interfaces;
using SalesWebMVC.Models.ViewModels;
using SalesWebMVC.Services.Exceptions;
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

        public virtual async Task<IActionResult> Index()
        {
            return View(await Service.FindAll());
        }

        public virtual async Task<IActionResult> Details(TKey id)
        {
            if (!Service.EntityExists(id))
                return RedirectToAction(nameof(Error), new {message = $"Resource with key {id} not found"});

            TEntity entity = await Service.Find(id);
            return View(entity);
        }

        public virtual IActionResult Create()
        {
            return View();
        }

        public virtual async Task<IActionResult> Edit(TKey id)
        {
            if (!Service.EntityExists(id))
                return RedirectToAction(nameof(Error), new { message = $"Resource with key {id} not found" });

            TEntity entity = await Service.Find(id);
            return View(entity);
        }

        public virtual async Task<IActionResult> Delete(TKey id)
        {
            if (!Service.EntityExists(id))
                return RedirectToAction(nameof(Error), new { message = $"Resource with key {id} not found" });

            TEntity entity = await Service.Find(id);
            return View(entity);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> DeleteConfirmed(TKey id)
        {
            if (!Service.EntityExists(id))
                return RedirectToAction(nameof(Error), new { message = $"Resource with key {id} not found" });

            try
            {
                await Service.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (DbIntegrityException)
            {
                return RedirectToAction(nameof(Error), new { message = "DBIntegrityException: Unable to delete resource" });
            }
        }

        public virtual IActionResult Error(string message)
        {
            ErrorViewModel viewModel = new ErrorViewModel(){Message = message, RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier};
            return View(viewModel);
        }
    }
}
