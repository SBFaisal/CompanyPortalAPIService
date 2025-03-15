using CompanyPortalDBService.Models.Entities;
using CompanyPortalDBService.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyPortalAPIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("GetAllEmployees")]
        public IActionResult GetAllEmployees()
        {
            return Ok(_employeeService.GetAllEmployees());
        }

        [HttpGet]
        [Route("GetEmployee/{id}")]
        public IActionResult GetEmployee(string id)
        {
            return Ok(_employeeService.GetEmployeeById(new Guid(id)));
        }

        [HttpPost]
        [Route("AddEmployee")]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            return Ok(_employeeService.AddEmployee(employee));
        }

        [HttpPost]
        [Route("UpdateEmployee")]
        public IActionResult UpdateEmployee([FromBody] Employee employee)
        {
            return Ok(_employeeService.UpdateEmployee(employee));
        }

        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public IActionResult DeleteEmployee(string id)
        {
            return Ok(_employeeService.DeleteEmployee(new Guid(id)));
        }
    }
}
