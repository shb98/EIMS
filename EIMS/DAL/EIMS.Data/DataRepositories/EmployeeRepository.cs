using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace EIMS.Data.DataRepositories
{
    [Export(typeof(IEmployeeRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class EmployeeRepository : DataRepositoryBase<Employee>, IEmployeeRepository
    {
        protected override Employee AddEntity(EIMSDataContext entityContext, Employee entity)
        {
            return entityContext.Employees.Add(entity);
        }

        protected override Employee UpdateEntity(EIMSDataContext entityContext, Employee entity)
        {
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
                select e);

            var results = query.FirstOrDefault();

            return results;
        }
    }
}