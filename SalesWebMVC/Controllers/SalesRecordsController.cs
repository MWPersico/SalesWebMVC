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
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecordService _service;

        public SalesRecordsController(SalesRecordService service)
        {
            _service = service;
        }

        // GET: SalesRecords
        public async Task<IActionResult> Index()
        {
            return View(await _service.FindAll());
        }

        // GET: SalesRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (!_service.EntityExists(id ?? -1))
                return NotFound();

            SalesRecord salesRecord = await _service.Find(id);
            return View(salesRecord);
        }

        // GET: SalesRecords/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SalesRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Amount,Status")] SalesRecord salesRecord)
        {
            if (!ModelState.IsValid)
                return View(salesRecord);

            await _service.Create(salesRecord);
            return RedirectToAction(nameof(Index));
        }

        // GET: SalesRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (!_service.EntityExists(id ?? -1))
                return NotFound();

            SalesRecord salesRecord = await _service.Find(id);
            return View(salesRecord);
        }

        // POST: SalesRecords/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Amount,Status")] SalesRecord salesRecord)
        {
            if(id != salesRecord.Id || !ModelState.IsValid)
                return View(salesRecord);

            await _service.Update(salesRecord);
            return RedirectToAction(nameof(Index));
        }

        // GET: SalesRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if(!_service.EntityExists(id ?? -1))
                return NotFound();

            SalesRecord salesRecord = await _service.Find(id);
            return View(salesRecord);
        }

        // POST: SalesRecords/Delete/5
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
