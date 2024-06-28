using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Data;
using SalesWebMVC.Models;

namespace SalesWebMVC.Services
{
    public class SellerService
    {
        private readonly SalesWebMVCContext _context;

        public SellerService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public async Task<IList<Seller>> FindAll()
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task<Seller?> Find(int? id)
        {
            return await _context.Seller.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task Create(Seller seller)
        {
            await _context.Seller.AddAsync(seller);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Seller seller = await Find(id);
            _context.Seller.Remove(seller);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Seller seller)
        {
            _context.Seller.Update(seller);
            await _context.SaveChangesAsync();
        }

        public bool SellerExists(int id)
        {
            return _context.Seller.Any(s => s.Id == id);
        }
    }
}
