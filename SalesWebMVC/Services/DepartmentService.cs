using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Data;
using SalesWebMVC.Models;

namespace SalesWebMVC.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMVCContext _context;

        public DepartmentService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public async Task<IList<Department>> FindAll()
        {
            return await _context.Department.ToListAsync();
        }

        public async Task<Department> Find(int? id)
        {
            if (!DepartmentExists(id ?? -1))
                throw new KeyNotFoundException();

            return await _context.Department.FirstOrDefaultAsync(d=>d.Id == id);
        }

        public async Task Create(Department department)
        {
            await _context.Department.AddAsync(department);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            _context.Department.Remove(await Find(id));
            await _context.SaveChangesAsync();
        }

        public async Task Update(Department department)
        {
            _context.Update(department);
            await _context.SaveChangesAsync();
        }

        public bool DepartmentExists(int id)
        {
            return _context.Department.Any(d => d.Id == id);
        }
    }
}
