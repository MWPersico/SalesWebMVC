using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;
using SalesWebMVC.Services;

namespace SalesWebMVC.Controllers
{
    public class SellersController : GenericController<Seller,int?>
    {
        public SellersController(SellerService service):base(service){}

        // TODO: RESOLVER PROBLEMA DE MATCHING DO MODELO, entidade Department "nula"
        public override async Task<IActionResult> Create([Bind("Id,Name,Email,BirthDate,Salary,Department")] Seller seller)
        {
            if (ModelState.IsValid)
            {
                await Service.Create(seller);
                return RedirectToAction(nameof(Index));
            }

            return View(seller);
        }

        // TODO: RESOLVER PROBLEMA DE MATCHING DO MODELO, entidade Department "nula"
        public override async Task<IActionResult> Edit(int? id, [Bind("Id,Name,Email,BirthDate,Salary")] Seller seller)
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
