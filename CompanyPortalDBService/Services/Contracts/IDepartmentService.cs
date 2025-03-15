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
        Department GetDepartmentById(Guid id);
        List<Department> GetAllParentDepartments();
        Department AddDepartment(Department department);
        Department UpdateDepartment(Department department);
        string DeleteDepartment(Guid id);
        List<Department> GetAllChildDepartments();
        List<Department> GetChildDepartmentsByParentId(Guid parentId);
    }
}
