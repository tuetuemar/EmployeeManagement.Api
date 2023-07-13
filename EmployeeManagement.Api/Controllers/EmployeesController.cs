using EmployeeManagement.Domain.IRepository;
using EmployeeManagement.Domain.IService;
using EmployeeManagement.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using System.Net;

namespace EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _service;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeesController> _logger;

        public EmployeesController(IEmployeeService service, IEmployeeRepository employeeRepository, ILogger<EmployeesController> logger)
        {
            _service = service;
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        [HttpGet(Name = nameof(GetAllEmployee))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<List<Employee>> GetAllEmployee()
        {
            List<Employee> response = await _service.GetAllAsync();
            return await Task.FromResult(response);
        }


        [HttpPost(Name = nameof(CreateEmployee))]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<EmployeeResponse> CreateEmployee(Employee request)
        {
            EmployeeResponse response = await _service.AddAsync(request);
            return await Task.FromResult(response);
        }


        [HttpPut(Name = nameof(UpdateEmployee))]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<EmployeeResponse> UpdateEmployee(Employee request)
        {
            EmployeeResponse response = await _service.UpdateAsync(request);
            return await Task.FromResult(response);
        }

        [HttpDelete("{id}", Name = nameof(DeleteEmployee))]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<EmployeeResponse> DeleteEmployee(int id)
        {
            EmployeeResponse response = await _service.DeleteAsync(id);
            return await Task.FromResult(response);
        }

    }
}
