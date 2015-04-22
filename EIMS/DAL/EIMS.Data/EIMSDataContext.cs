using System.Data.Entity;

namespace EIMS.Data
{
    public class EIMSDataContext : DbContext
    {
        public EIMSDataContext()
            : base("EIMS")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<EIMSDataContext>());
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EmployeeMovement> EmployeeMovements { get; set; }
        public DbSet<VacationRequest> VacationRequests { get; set; }
        public DbSet<SalaryReport> SalaryReports { get; set; } 
    }
}