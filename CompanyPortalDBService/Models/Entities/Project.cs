using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyPortalDBService.Models.Entities
{
    public class Project
    {

        public required Guid Id { get; set; }
        public required string ProjectName { get; set; }
        public string? ClientName { get; set; }
        public required Guid LeadByEmployeeId { get; set; }
        public required Guid DepartmentId { get; set; }
        public DateTime StartDate { get; set; }

    }
}
