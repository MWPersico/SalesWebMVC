using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Data;
using SalesWebMVC.Models;
using SalesWebMVC.Services;

namespace SalesWebMVC.Controllers
{
    // OBS: Classe Controlle gerado apartir de modelo MVC com operações básicas, integrado ao Entity Framework: add>new scaffolded file>mvc controller with views, using entity framework 
    public class DepartmentsController : Controller
    {
        private readonly DepartmentService _service;

        public DepartmentsController(DepartmentService service)
        {
            _service = service;
        }

        // GET: Departments
        public async Task<IActionResult> Index()
        {
            return View(await _service.FindAll());
        }

        // GET: Departments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (!_service.DepartmentExists(id ?? -1))
                return NotFound();

            Department department = await _service.Find(id);
            return View(department);
        }

        // GET: Departments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Department department)
        {
            if(!ModelState.IsValid)
                return View(department);

            await _service.Create(department);
            return RedirectToAction(nameof(Index));
        }

        // GET: Departments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if(!_service.DepartmentExists(id ?? -1))
                return NotFound();

            Department department = await _service.Find(id);
            return View(department);
        }

        // POST: Departments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Department department)
        {
            if (id != department.Id || !_service.DepartmentExists(id))
                return NotFound();

            if (!ModelState.IsValid)
                return View(department);

            await _service.Update(department);
            return RedirectToAction(nameof(Index));
        }

        // GET: Departments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if(!_service.DepartmentExists(id ?? -1))
                return NotFound();

            Department department = await _service.Find(id);
            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if(!_service.DepartmentExists(id))
                return NotFound();

            await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
