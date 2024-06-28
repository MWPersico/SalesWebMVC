using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;
using SalesWebMVC.Services;

namespace SalesWebMVC.Controllers
{
    public class SalesRecordsController : GenericController<SalesRecord, int?>
    {
        private readonly SalesRecordService _service;

        public SalesRecordsController(SalesRecordService service):base(service){}

        // TODO: RESOLVER PROBLEMA DE MATCHING DO MODELO, entidade Department "nula"
        public override async Task<IActionResult> Create([Bind("Id,Date,Amount,Status")] SalesRecord salesRecord)
        {
            if (!ModelState.IsValid)
                return View(salesRecord);

            await _service.Create(salesRecord);
            return RedirectToAction(nameof(Index));
        }

        // TODO: RESOLVER PROBLEMA DE MATCHING DO MODELO, entidade Department "nula"
        public override async Task<IActionResult> Edit(int? id, [Bind("Id,Date,Amount,Status")] SalesRecord salesRecord)
        {
            if(id != salesRecord.Id || !ModelState.IsValid)
                return View(salesRecord);

            await _service.Update(id, salesRecord);
            return RedirectToAction(nameof(Index));
        }
    }
}
