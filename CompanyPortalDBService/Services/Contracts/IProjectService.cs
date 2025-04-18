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
        Project GetProjectById(string id);
        bool AddProject(Project project);
        bool UpdateProject(Project project, string id);
        bool DeleteProject(string id);
        List<Project> GetAllProjectsByDepartmentId(string id);
    }
}
