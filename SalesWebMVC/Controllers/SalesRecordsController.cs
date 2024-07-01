using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;
using SalesWebMVC.Models.ViewModels;
using SalesWebMVC.Services;
using SalesWebMVC.Services.Exceptions;

namespace SalesWebMVC.Controllers
{
    public class SalesRecordsController : GenericController<SalesRecord, int?>
    {
        private readonly SellerService _sellerService;

        public SalesRecordsController(SalesRecordService service, SellerService sellerService) : base(service)
        {
            _sellerService = sellerService;
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            minDate = minDate ?? new DateTime(DateTime.Now.Year-8, 1, 1);
            maxDate = maxDate ?? DateTime.Now;

            IEnumerable<SalesRecord> sales = await ((SalesRecordService)Service).FindByDate(minDate.Value, maxDate.Value);
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            return View(sales);
        }

        public IActionResult GroupSearch(DateTime? minDate, DateTime? maxDate)
        {
            minDate = minDate ?? new DateTime(DateTime.Now.Year - 8, 1, 1);
            maxDate = maxDate ?? DateTime.Now;

            IEnumerable<IGrouping<Department, SalesRecord>> sales = ((SalesRecordService)Service).FindGroupedByDepartment(minDate.Value, maxDate.Value);
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            return View(sales);
        }

        public override IActionResult Create()
        {
            IList<Seller> sellers = _sellerService.FindAll().Result;
            SalesRecordFormViewModel viewModel = new SalesRecordFormViewModel() { Sellers = sellers };
            return View(viewModel);
        }

        public override async Task<IActionResult> Edit(int? id)
        {
            if (!Service.EntityExists(id))
                return RedirectToAction(nameof(Error), new { message = $"Resource with key {id} not found" });

            SalesRecord entity = await Service.Find(id);
            SalesRecordFormViewModel viewModel = new SalesRecordFormViewModel()
                { SalesRecord = entity, Sellers = await _sellerService.FindAll() };
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

        public override async Task<IActionResult> Edit(int? id, [Bind("Id,Date,Amount,Status,SellerId")] SalesRecord salesRecord)
        {
            if (id != salesRecord.Id || !ModelState.IsValid)
            {
                SalesRecord entity = await Service.Find(id);
                SalesRecordFormViewModel viewModel = new SalesRecordFormViewModel()
                    { SalesRecord = entity, Sellers = await _sellerService.FindAll() };
                return View(viewModel);
            }

            try
            {
                await Service.Update(id, salesRecord);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction(nameof(Error), ex.Message);
            }
        }
    }
}
