using CompanyPortalDBService.Models.Entities;
using CompanyPortalDBService.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CompanyPortalAPIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        [Route("GetAllProjects")]
        public IActionResult GetAllProjects()
        {
            try
            {
                var response = _projectService.GetAllProjects();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetProjectById/{id}")]
        public IActionResult GetProjectById(string id)
        {
            try
            {
                var response = _projectService.GetProjectById(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("AddProject")]
        public IActionResult AddProject([FromBody] Project project)
        {
            try
            {
                var isSuccess = _projectService.AddProject(project);
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
        [Route("UpdateProject")]
        public IActionResult UpdateProject([FromBody] Project project, string id)
        {
            try
            {
                var isSuccess = _projectService.UpdateProject(project, id);
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
        [Route("DeleteProject/{id}")]
        public IActionResult DeleteProject(string id)
        {
            try
            {
                var isSuccess = _projectService.DeleteProject(id);
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

        [HttpGet]
        [Route("GetAllProjectsByDepartmentId/{id}")]
        public IActionResult GetAllProjectsByDepartmentId(string id)
        {
            try
            {
                var response = _projectService.GetAllProjectsByDepartmentId(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
