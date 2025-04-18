using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyPortalDBService.Models.DTO
{
    public class EmployeeDTO
    {
        public string EmployeeName { get; set; }
        public string ContactNo { get; set; }
        public string EmailId { get; set; }
        public string DeparmentName { get; set; }
        public string ProjectName { get; set; }
        public string Gender { get; set; }
        public string Role { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
