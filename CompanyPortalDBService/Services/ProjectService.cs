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
        public Project GetProjectById(string id)
        {
            Guid parsedId = Guid.Empty;
            if (!Guid.TryParse(id, out parsedId))
            {
                return null;
            }
            try
            {
                var project = _context.Projects.Find(parsedId);
                if(project != null)
                {
                    return project;
                }                
            }
            catch
            {
                return null;
            }
            return null;
        }
        public bool AddProject(Project project)
        {
            try
            {
                _context.Projects.Add(project);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateProject(Project project, string id)
        {
            Guid parsedId = Guid.Empty;
            if (!Guid.TryParse(id, out parsedId))
            {
                return false;
            }
            try
            {
                var obj = _context.Projects.FirstOrDefault(e => e.Id == parsedId);
                if (obj != null)
                {

                    _context.Projects.Update(project);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                throw;
            }

        }
        public bool DeleteProject(string id)
        {
            Guid parsedId = Guid.Empty;
            if (!Guid.TryParse(id, out parsedId))
            {
                return false;
            }
            try
            {


                var project = _context.Projects.FirstOrDefault(e => e.Id == parsedId);
                if (project != null)
                {
                    _context.Projects.Remove(project);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                throw;
            }
        }

        public List<Project> GetAllProjectsByDepartmentId(string id)
        {
            Guid parsedId = Guid.Empty;
            if (!Guid.TryParse(id, out parsedId))
            {
                return null;
            }
            return _context.Projects.Where(e => e.DepartmentId == parsedId).ToList();
        }
    }
}
