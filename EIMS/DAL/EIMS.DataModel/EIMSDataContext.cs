using System.Data.Entity;

namespace EIMS.DataModel
{
    public class EIMSDataContext : DbContext
    {
        public EIMSDataContext()
            : base("EIMSDataContext")
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}