using CompanyPortalDBService.Models.Entities;
using CompanyPortalDBService.Services;
using CompanyPortalDBService.Services.Contracts;
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
            return Ok(_employeeService.GetEmployeeById(id));
        }

        [HttpPost]
        [Route("AddEmployee")]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            try
            {
                bool isSuccess = _employeeService.AddEmployee(employee);
                if (isSuccess)
                {
                    return Ok(true);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest("Some Error Occured!!!");
            }
        }

        [HttpPost]
        [Route("UpdateEmployee")]
        public IActionResult UpdateEmployee([FromBody] Employee employee, string id)
        {
            try
            {
                bool isSuccess = _employeeService.UpdateEmployee(employee, id);
                if (isSuccess)
                {
                    return Ok(true);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest("Some Error Occured!!!");
            }
        }

        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public IActionResult DeleteEmployee(string id)
        {
            try
            {
                bool isSuccess = _employeeService.DeleteEmployee(id);
                if (isSuccess)
                {
                    return Ok(true);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest("Some Error Occured!!!");
            }
        }
    }
}
