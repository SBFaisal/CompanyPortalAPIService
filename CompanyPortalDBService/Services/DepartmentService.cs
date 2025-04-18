using CompanyPortalDBService.DbContext;
using CompanyPortalDBService.Models.Entities;
using CompanyPortalDBService.Services.Contracts;
using System.Runtime.CompilerServices;

namespace CompanyPortalDBService.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly CompanyPortalDBContext _context;
        public DepartmentService(CompanyPortalDBContext context)
        {
            _context = context;
        }

        public List<Department> GetAllDepartments()
        {
            return _context.Departments.ToList();
        }
        public Department GetDepartmentById(string id)
        {
            Guid parsedId = Guid.Empty;
            if(!Guid.TryParse(id, out parsedId))
            {
                return null; 
            }
            try
            {
                var department = _context.Departments.FirstOrDefault(e => e.Id == parsedId);
                if (department != null)
                {
                    return department;
                }
            }
            catch
            {
                return null;
            }
            return null;
        }
        public List<Department> GetAllParentDepartments()
        {
            return _context.Departments.Where(e => e.ParentDepartmentId == null).ToList();
        }
        public bool AddDepartment(Department department)
        {
            try
            {
                _context.Departments.Add(department);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool UpdateDepartment(Department department, string id)
        {
            Guid parsedId = Guid.Empty;
            if (!Guid.TryParse(id, out parsedId))
            {
                return false;
            }
            try
            {
                var obj = _context.Departments.Find(parsedId);
                if (obj != null)
                {
                    _context.Departments.Update(department);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public bool DeleteDepartment(string id)
        {
            Guid parsedId = Guid.Empty;
            if (!Guid.TryParse(id, out parsedId))
            {
                return false;
            }
            try
            {
                var department = _context.Departments.FirstOrDefault(e => e.Id == parsedId);
                if (department != null)
                {
                    _context.Departments.Remove(department);
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
        public List<Department> GetAllChildDepartments()
        {
            return _context.Departments.Where(e => e.ParentDepartmentId != null).ToList();
        }
        public List<Department> GetChildDepartmentsByParentId(string parentId)
        {
            Guid parsedId = Guid.Empty;
            if (!Guid.TryParse(parentId, out parsedId))
            {
                return null;
            }
            return _context.Departments.Where(e => e.ParentDepartmentId == parsedId).ToList();
        }


    }
}
