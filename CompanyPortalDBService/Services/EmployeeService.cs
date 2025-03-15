using CompanyPortalDBService.DbContext;
using CompanyPortalDBService.Models.Entities;
using CompanyPortalDBService.Services.Contracts;

namespace CompanyPortalDBService.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly CompanyPortalDBContext _context;
        public EmployeeService(CompanyPortalDBContext context)
        {
            _context = context;
        }

        public List<Employee> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }

        public Employee GetEmployeeById(Guid id)
        {
            return _context.Employees.FirstOrDefault(e => e.Id == id);
        }

        public Employee AddEmployee(Employee employee)
        {
            try
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return employee;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Employee UpdateEmployee(Employee employee)
        {
            try
            {
                _context.Employees.Update(employee);
                _context.SaveChanges();
                return employee;
            }
            catch
            {
                return null;
            }

        }

        public string DeleteEmployee(Guid id)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
                return "Employee deleted successfully";
            }
            return "Employee not found";
        }

    }
}
