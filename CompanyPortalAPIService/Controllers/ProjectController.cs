using CompanyPortalDBService.Models.Entities;
using CompanyPortalDBService.Services.Contracts;
using Microsoft.AspNetCore.Http;
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
                var response = _projectService.GetProjectById(new Guid(id));
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
                var response = _projectService.AddProject(project);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("UpdateProject")]
        public IActionResult UpdateProject([FromBody] Project project)
        {
            try
            {
                var response = _projectService.UpdateProject(project);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteProject/{id}")]
        public IActionResult DeleteProject(string id)
        {
            try
            {
                var response = _projectService.DeleteProject(new Guid(id));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetAllProjectsByDepartmentId/{id}")]
        public IActionResult GetAllProjectsByDepartmentId(string id)
        {
            try
            {
                var response = _projectService.GetAllProjectsByDepartmentId(new Guid(id));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
