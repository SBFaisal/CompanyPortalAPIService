using CompanyPortalDBService.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyPortalDBService.Services.Contracts
{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployees();
        Employee GetEmployeeById(Guid id);
        Employee AddEmployee(Employee employee);
        Employee UpdateEmployee(Employee employee);
        string DeleteEmployee(Guid id);
    }
}
