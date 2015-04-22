using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Linq;

namespace EIMS.Data.DataRepositories
{
    [Export(typeof(IEmployeeProfileRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class EmployeeProfileRepository : DataRepositoryBase<Employee>, IEmployeeProfileRepository
    {
        protected override Employee AddEntity(EIMSDataContext entityContext, Employee entity)
        {
            return entityContext.Employees.Add(entity);
        }

        protected override Employee UpdateEntity(EIMSDataContext entityContext, Employee entity,
            out List<string> ignoredProperties)
        {
            ignoredProperties = new List<string>
            {
                "Title",
                "Department"
            };

            return (from e in entityContext.Employees
                where e.EmployeeId == entity.EmployeeId
                select e).FirstOrDefault();
        }

        protected override IEnumerable<Employee> GetEntities(EIMSDataContext entityContext)
        {
            return from e in entityContext.Employees
                select e;
        }

        protected override Employee GetEntity(EIMSDataContext entityContext, int id)
        {
            var query = (from e in entityContext.Employees
                where e.EmployeeId == id
                select e).Include(e=>e.Department);

            var results = query.FirstOrDefault();

            return results;
        }
    }
}