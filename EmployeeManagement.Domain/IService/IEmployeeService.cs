using EmployeeManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Domain.IService
{
    public interface IEmployeeService
    {
        public  Task<EmployeeResponse> AddAsync(Employee model);
        public Task<EmployeeResponse> UpdateAsync(Employee model);
        public Task<EmployeeResponse> DeleteAsync(int id);
        public Task<List<Employee>> GetAllAsync();
    }
}
