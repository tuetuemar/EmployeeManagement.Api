using EmployeeManagement.Domain.IRepository;
using EmployeeManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.Ef.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _context;
        
        private readonly ILogger<EmployeeRepository> _logger;

        public EmployeeRepository(EmployeeContext context, ILogger<EmployeeRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employee
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {

            return await _context.Employee
             //   .Where(x => x.IsDeleted == false)
                .FirstOrDefaultAsync(c => c.Id == id);

        }
        public async Task<bool> AddAsync(Employee model)
        {
            _context.Add(model);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Employee model)
        {
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var model = await _context.Employee.FindAsync(id);
            if (model == null)
                return false;
            _context.Remove(model);
            await _context.SaveChangesAsync();
            return true;

        }
    }
}
