using CompanyPortalDBService.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyPortalDBService.Services.Contracts
{
    public interface IDepartmentService
    {
        List<Department> GetAllDepartments();
        Department GetDepartmentById(string id);
        List<Department> GetAllParentDepartments();
        bool AddDepartment(Department department);
        bool UpdateDepartment(Department department, string id);
        bool DeleteDepartment(string id);
        List<Department> GetAllChildDepartments();
        List<Department> GetChildDepartmentsByParentId(string parentId);
    }
}
