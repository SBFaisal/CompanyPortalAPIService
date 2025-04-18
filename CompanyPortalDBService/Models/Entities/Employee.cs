using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyPortalDBService.Models.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public required string EmployeeName { get; set; }
        public string? ContactNo { get; set; }
        public required string EmailId { get; set; }
        public Guid DeparmentId { get; set; }
        public Guid? ProjectId { get; set; }
        public required string Password { get; set; }
        public string? Gender { get; set; }
        public string? Role { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
