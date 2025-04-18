using CompanyPortalDBService.Models.Entities;
using CompanyPortalDBService.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CompanyPortalAPIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService employeeService)
        {
            _departmentService = employeeService;
        }

        [HttpGet]
        [Route("GetAllDepartments")]
        public IActionResult GetAllDepartments()
        {
            try
            {
                var response = _departmentService.GetAllDepartments();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
        [HttpGet]
        [Route("GetDepartmentById/{id}")]
        public IActionResult GetDepartmentById(string id)
        {
            try
            {
                var response = _departmentService.GetDepartmentById(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetAllParentDepartments")]
        public IActionResult GetAllParentDepartments()
        {
            try
            {
                var response = _departmentService.GetAllParentDepartments();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("AddDepartment")]
        public IActionResult AddDepartment(Department department)
        {
            try
            {
                bool isSuccess = _departmentService.AddDepartment(department);
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
        [Route("UpdateDepartment")]
        public IActionResult UpdateDepartment([FromBody] Department department, string id)
        {
            try
            {
                var isSuccess = _departmentService.UpdateDepartment(department, id);
                if (isSuccess)
                {
                    return Ok(true);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteDepartment/{id}")]
        public IActionResult DeleteDepartment(string id)
        {
            try
            {
                var isSuccess = _departmentService.DeleteDepartment(id);
                if (isSuccess)
                {
                    return Ok(true);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetAllChildDepartments")]
        public IActionResult GetAllChildDepartments()
        {
            return Ok(_departmentService.GetAllChildDepartments());
        }

        [HttpGet]
        [Route("GetChildDepartmentsByParentId/{parentId}")]
        public IActionResult GetChildDepartmentsByParentId(string parentId)
        {
            return Ok(_departmentService.GetChildDepartmentsByParentId(parentId));
        }
    }
}
