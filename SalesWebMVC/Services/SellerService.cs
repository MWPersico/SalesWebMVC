using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Data;
using SalesWebMVC.Models;

namespace SalesWebMVC.Services
{
    public class SellerService(SalesWebMVCContext context) : GenericService<Seller, int?>(context)
    {
        public override async Task<Seller> Find(int? key)
        {
            if (!EntityExists(key))
                throw new KeyNotFoundException();

            return await Context.Set<Seller>().Include(s => s.Department).FirstOrDefaultAsync(s=>s.Id == key);
        }
    };
}
