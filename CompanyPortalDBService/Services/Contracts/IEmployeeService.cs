using CompanyPortalDBService.Models.DTO;
using CompanyPortalDBService.Models.Entities;

namespace CompanyPortalDBService.Services.Contracts
{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployees();
        EmployeeDTO GetEmployeeById(string id);
        bool AddEmployee(Employee employee);
        bool UpdateEmployee(Employee employee, string id);
        bool DeleteEmployee(string id);
    }
}
