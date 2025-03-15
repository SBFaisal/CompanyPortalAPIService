using CompanyPortalDBService.DbContext;
using CompanyPortalDBService.Models.Entities;
using CompanyPortalDBService.Services.Contracts;

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
        public Department GetDepartmentById(Guid id)
        {
            return _context.Departments.FirstOrDefault(e => e.Id == id);
        }
        public List<Department> GetAllParentDepartments()
        {
            return _context.Departments.Where(e => e.ParentDepartmentId == null).ToList();
        }
        public Department AddDepartment(Department department)
        {
            try
            {
                _context.Departments.Add(department);
                _context.SaveChanges();
                return department;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public Department UpdateDepartment(Department department)
        {
            try
            {
                _context.Departments.Update(department);
                _context.SaveChanges();
                return department;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public string DeleteDepartment(Guid id)
        {
            var department = _context.Departments.FirstOrDefault(e => e.Id == id);
            if (department != null)
            {
                _context.Departments.Remove(department);
                _context.SaveChanges();
                return "Department deleted successfully";
            }
            return "Department not found";
        }
        public List<Department> GetAllChildDepartments()
        {
            return _context.Departments.Where(e => e.ParentDepartmentId != null).ToList();
        }
        public List<Department> GetChildDepartmentsByParentId(Guid parentId)
        {
            return _context.Departments.Where(e => e.ParentDepartmentId == parentId).ToList();
        }


    }
}
