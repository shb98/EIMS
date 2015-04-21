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
    }
}