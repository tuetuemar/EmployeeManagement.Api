using EmployeeManagement.Domain.IRepository;
using EmployeeManagement.Domain.IService;
using EmployeeManagement.Domain.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repo;
        private readonly ILogger<EmployeeService> _logger;
        private EmployeeResponse response = new EmployeeResponse();
        public EmployeeService(IEmployeeRepository repo,
            ILogger<EmployeeService> logger)
        {
            _repo = repo;
            _logger = logger;
        }
        public async Task<EmployeeResponse> AddAsync(Employee model)
        {
            if (await _repo.AddAsync(model))
                response.Code = "201";
            response.Name = "Success";
            return response;


        }

        public async Task<EmployeeResponse> DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
            response.Code = "200";
            response.Name = "Success";
            return response;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            List<Employee> model = await _repo.GetAllAsync();
            return model.ToList();
        }

        public async Task<EmployeeResponse> UpdateAsync(Employee model)
        {
            if (await _repo.UpdateAsync(model))
                response.Code = "201";
            response.Name = "Success";
            return response;
        }
    }
}
