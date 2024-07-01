using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;
using SalesWebMVC.Models.ViewModels;
using SalesWebMVC.Services;

namespace SalesWebMVC.Controllers
{
    public class SellersController : GenericController<Seller,int?>
    {
        private DepartmentService _departmentService;
        public SellersController(SellerService service, DepartmentService departmentService) : base(service)
        {
            _departmentService = departmentService;
        }

        public override IActionResult Create()
        {
            // loading departments for select field
            IList<Department> departments = _departmentService.FindAll().Result;
            SellerFormViewModel viewModel = new SellerFormViewModel(){Departments = departments};

            return View(viewModel);
        }

        public override async Task<IActionResult> Edit(int? id)
        {
            if (!Service.EntityExists(id))
                return NotFound();

            Seller entity = await Service.Find(id);
            IList<Department> departments = await _departmentService.FindAll();
            SellerFormViewModel viewModel = new SellerFormViewModel() {Departments = departments, Seller = entity};
            return View(viewModel);
        }

        public override async Task<IActionResult> Create(Seller seller)
        {
            if (ModelState.IsValid)
            {
                await Service.Create(seller);
                return RedirectToAction(nameof(Index));
            }

            SellerFormViewModel viewModel = new SellerFormViewModel() { Departments = await _departmentService.FindAll(), Seller = seller };
            return View(viewModel);
        }

        public override async Task<IActionResult> Edit(int? id, [Bind("Id,Name,Email,BirthDate,Salary,DepartmentId")] Seller seller)
        {
            if (id != seller.Id || !Service.EntityExists(id)) 
                return NotFound();

            if (!ModelState.IsValid)
                return View(seller);

            await Service.Update(id, seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
