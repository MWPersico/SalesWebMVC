using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Data;
using SalesWebMVC.Models;

namespace SalesWebMVC.Services
{
    public class SalesRecordService(SalesWebMVCContext context) : GenericService<SalesRecord, int?>(context)
    {
        public override async Task<IList<SalesRecord>> FindAll()
        {
            return await Context.SalesRecord.Include(sr=>sr.Seller).OrderByDescending(sr=>sr.Date).ToListAsync();
        }

        public async Task<IList<SalesRecord>> FindByDate(DateTime minDate, DateTime maxDate)
        {
            return await Context.SalesRecord
                .Include(sr=>sr.Seller)
                .Include(sr=>sr.Seller.Department)
                .Where(sr => sr.Date >= minDate && sr.Date <= maxDate)
                .ToListAsync();
        }

        public IEnumerable<IGrouping<Department, SalesRecord>> FindGroupedByDepartment(DateTime minDate, DateTime maxDate)
        {
            return Context.SalesRecord
                .Include(sr=>sr.Seller)
                .Include(sr=>sr.Seller.Department)
                .Where(sr => sr.Date >= minDate && sr.Date <= maxDate)
                .GroupBy(sr=>sr.Seller.Department);
        }

        public override async Task<SalesRecord> Find(int? key)
        {
            if (!EntityExists(key))
                throw new KeyNotFoundException();

            return await Context.SalesRecord.Include(sr=>sr.Seller).FirstOrDefaultAsync(sr=>sr.Id == key);
        }
    };
}
