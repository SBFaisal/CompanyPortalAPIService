using CompanyPortalDBService.DbContext;
using CompanyPortalDBService.Models.DTO;
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

        public EmployeeDTO GetEmployeeById(string id)
        {
            Guid parsedId = Guid.Empty;
            if (!Guid.TryParse(id, out parsedId))
            {
                return null;
            }
            try
            {
                var employee = _context.Employees.Find(parsedId);
                if (employee != null)
                {
                    return createEmployeeDTO(employee);
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

        public bool AddEmployee(Employee employee)
        {
            try
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateEmployee(Employee employee, string id)
        {
            Guid parsedId = Guid.Empty;
            if (!Guid.TryParse(id, out parsedId))
            {
                return false;
            }
            try
            {
                var obj = _context.Employees.Find(parsedId);
                if (obj != null)
                {
                    _context.Employees.Update(employee);
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

        public bool DeleteEmployee(string id)
        {
            Guid parsedId = Guid.Empty;
            if (!Guid.TryParse(id, out parsedId))
            {
                return false;
            }
            try
            {
                var employee = _context.Employees.FirstOrDefault(e => e.Id == parsedId);
                if (employee != null)
                {
                    _context.Employees.Remove(employee);
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

        private EmployeeDTO createEmployeeDTO(Employee employee)
        {
            EmployeeDTO employeeDTO = new EmployeeDTO
            {
                EmployeeName = employee.EmployeeName,
                ContactNo = employee.ContactNo,
                EmailId = employee.EmailId,
                DeparmentName = employee.DeparmentId.ToString(),
                ProjectName = employee.ProjectId.ToString(),
                Gender = employee.Gender,
                Role = employee.Role,
                CreatedDate = employee.CreatedDate
            };
            return employeeDTO;
        }
    }
}
