using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyPortalDBService.Models.Entities
{
    public class Department
    {
        public Guid Id { get; set; }
        public required string DepartmentName { get; set; }
        public string? Logo { get; set; }
        public Guid? ParentDepartmentId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
