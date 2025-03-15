using CompanyPortalDBService.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyPortalDBService.Services.Contracts
{
    public interface IProjectService
    {
        List<Project> GetAllProjects();
        Project GetProjectById(Guid id);
        Project AddProject(Project project);
        Project UpdateProject(Project project);
        string DeleteProject(Guid id);
        List<Project> GetAllProjectsByDepartmentId(Guid id);
    }
}
