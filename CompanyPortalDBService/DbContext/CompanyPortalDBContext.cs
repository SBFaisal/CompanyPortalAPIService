using CompanyPortalDBService.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyPortalDBService.DbContext
{
    public class CompanyPortalDBContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public CompanyPortalDBContext(DbContextOptions<CompanyPortalDBContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Project> Projects { get; set; }
    }
}
