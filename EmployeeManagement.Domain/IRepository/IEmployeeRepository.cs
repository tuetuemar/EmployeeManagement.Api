using EmployeeManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Domain.IRepository
{
    public interface IEmployeeRepository
    {
        public Task<List<Employee>> GetAllAsync();
        public Task<Employee> GetEmployeeById(int id);
        public Task<bool> AddAsync(Employee model);
        public Task<bool> UpdateAsync(Employee model);
        public Task<bool> DeleteAsync(int id);
    }
}
