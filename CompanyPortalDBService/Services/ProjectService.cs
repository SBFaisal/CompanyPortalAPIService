using CompanyPortalDBService.DbContext;
using CompanyPortalDBService.Models.Entities;
using CompanyPortalDBService.Services.Contracts;

namespace CompanyPortalDBService.Services
{
    public class ProjectService : IProjectService
    {
        private readonly CompanyPortalDBContext _context;
        public ProjectService(CompanyPortalDBContext context)
        {
            _context = context;
        }

        public List<Project> GetAllProjects()
        {
            return _context.Projects.ToList();
        }
        public Project GetProjectById(Guid id)
        {
            return _context.Projects.FirstOrDefault(e => e.Id == id);
        }
        public Project AddProject(Project project)
        {
            try
            {
                _context.Projects.Add(project);
                _context.SaveChanges();
                return project;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Project UpdateProject(Project project)
        {
            try
            {
                _context.Projects.Update(project);
                _context.SaveChanges();
                return project;
            }
            catch
            {
                return null;
            }

        }
        public string DeleteProject(Guid id)
        {
            var project = _context.Projects.FirstOrDefault(e => e.Id == id);
            if (project != null)
            {
                _context.Projects.Remove(project);
                _context.SaveChanges();
                return "Project deleted successfully";
            }
            return "Project not found";
        }

        public List<Project> GetAllProjectsByDepartmentId(Guid id)
        {
            return _context.Projects.Where(e => e.DepartmentId == id).ToList();
        }
    }
}
