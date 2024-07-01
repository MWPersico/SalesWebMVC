using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Data;
using SalesWebMVC.Models;

namespace SalesWebMVC.Services
{
    public class SalesRecordService(SalesWebMVCContext context) : GenericService<SalesRecord, int?>(context)
    {
        public override async Task<SalesRecord> Find(int? key)
        {
            if (!EntityExists(key))
                throw new KeyNotFoundException();

            return await Context.SalesRecord.Include(sr=>sr.Seller).FirstOrDefaultAsync(sr=>sr.Id == key);
        }
    };
}
