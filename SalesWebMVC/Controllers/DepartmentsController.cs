using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;
using SalesWebMVC.Services;

namespace SalesWebMVC.Controllers
{
    // OBS: Classe Controlle gerado apartir de modelo MVC com operações básicas, integrado ao Entity Framework: add>new scaffolded file>mvc controller with views, using entity framework 
    public class DepartmentsController : GenericController<Department, int?>
    {
        public DepartmentsController(DepartmentService service):base(service){}

        public override async Task<IActionResult> Create([Bind("Id,Name")] Department department)
        {
            if (!ModelState.IsValid)
                return View(department);

            await Service.Create(department);
            return RedirectToAction(nameof(Index));
        }

        public override async Task<IActionResult> Edit(int? id, [Bind("Id,Name")] Department department)
        {
            if (id != department.Id || !Service.EntityExists(id))
                return RedirectToAction(nameof(Error), new { message = $"Resource with key {id} not found" });

            if (!ModelState.IsValid)
                return View(department);

            try
            {
                await Service.Update(id, department);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction(nameof(Error), ex.Message);
            }
        }
    }
}
