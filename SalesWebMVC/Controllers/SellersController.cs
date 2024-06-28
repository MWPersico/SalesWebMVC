using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Models;
using SalesWebMVC.Services;

namespace SalesWebMVC.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _service;

        public SellersController(SellerService service)
        {
            _service = service;
        }

        // GET: Sellers
        public async Task<IActionResult> Index()
        {
            IList<Seller> sellers = await _service.FindAll();
            return View(sellers);
        }

        // GET: Sellers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (!_service.EntityExists(id ?? -1))
                return NotFound();

            Seller seller = await _service.Find(id);
            return View(seller);
        }

        // GET: Sellers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sellers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,BirthDate,Salary,Department")] Seller seller)
        {
            if (ModelState.IsValid)
            {
                await _service.Create(seller);
                return RedirectToAction(nameof(Index));
            }

            return View(seller);
        }

        // GET: Sellers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (!_service.EntityExists(id ?? -1))
                return NotFound();

            Seller seller = await _service.Find(id);
            return View(seller);
        }

        // POST: Sellers/Edit/5
        // TODO: FIX NAVIGATION PROPERTY DEPARTMENT "null"
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,BirthDate,Salary")] Seller seller)
        {
            if (id != seller.Id || !_service.EntityExists(id)) 
                return NotFound();

            if (!ModelState.IsValid)
                return View(seller);

            await _service.Update(seller);
            return RedirectToAction(nameof(Index));
        }

        // GET: Sellers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (!_service.EntityExists(id??-1))
                return NotFound();

            Seller seller = await _service.Find(id);
            return View(seller);
        }

        // POST: Sellers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!_service.EntityExists(id))
                return NotFound();

            await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
