using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;
using SalesWebMVC.Models.ViewModels;
using SalesWebMVC.Services;

namespace SalesWebMVC.Controllers
{
    public class SalesRecordsController : GenericController<SalesRecord, int?>
    {
        private readonly SellerService _sellerService;

        public SalesRecordsController(SalesRecordService service, SellerService sellerService) : base(service)
        {
            _sellerService = sellerService;
        }

        public override IActionResult Create()
        {
            IList<Seller> sellers = _sellerService.FindAll().Result;
            SalesRecordFormViewModel viewModel = new SalesRecordFormViewModel() { Sellers = sellers };
            return View(viewModel);
        }

        public override async Task<IActionResult> Create(SalesRecord salesRecord)
        {
            if (!ModelState.IsValid)
            {
                SalesRecordFormViewModel viewModel = new SalesRecordFormViewModel(){SalesRecord = salesRecord, Sellers = await _sellerService.FindAll()};
                return View(viewModel);
            }
                

            await Service.Create(salesRecord);
            return RedirectToAction(nameof(Index));
        }

        public override async Task<IActionResult> Edit(int? id, [Bind("Id,Date,Amount,Status")] SalesRecord salesRecord)
        {
            if(id != salesRecord.Id || !ModelState.IsValid)
                return View(salesRecord);

            await Service.Update(id, salesRecord);
            return RedirectToAction(nameof(Index));
        }
    }
}
