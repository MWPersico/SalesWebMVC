using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Data;
using SalesWebMVC.Models;

namespace SalesWebMVC.Services
{
    public class SalesRecordService
    {
        private readonly SalesWebMVCContext _context;

        public SalesRecordService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public async Task<IList<SalesRecord>> FindAll()
        {
            return await _context.SalesRecord.ToListAsync();
        }
        public async Task<SalesRecord> Find(int? id)
        {
            if(!SalesRecordExists(id ?? -1))
                throw new KeyNotFoundException();

            return await _context.SalesRecord.FirstOrDefaultAsync(sr=>sr.Id == id);
        }

        public async Task Create(SalesRecord salesRecord)
        {
            await _context.SalesRecord.AddAsync(salesRecord);
            await _context.SaveChangesAsync();
        }

        public async Task Update(SalesRecord salesRecord)
        {
            await _context.SalesRecord.AddAsync(salesRecord);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            _context.SalesRecord.Remove(await Find(id));
            await _context.SaveChangesAsync();
        
        }

        public bool SalesRecordExists(int id) {
            return _context.SalesRecord.Any(sr => sr.Id == id);
        }
    }
}
