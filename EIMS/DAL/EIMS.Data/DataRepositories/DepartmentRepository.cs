using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIMS.Data.DataRepositories
{
    [Export(typeof(IDepartmentRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DepartmentRepository : DataRepositoryBase<Department>, IDepartmentRepository
    {
        protected override Department AddEntity(EIMSDataContext entityContext, Department entity)
        {
            return entityContext.Departments.Add(entity);
        }

        protected override Department UpdateEntity(EIMSDataContext entityContext, Department entity)
        {
            return (from e in entityContext.Departments
                    where e.DepartmentId == entity.DepartmentId
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<Department> GetEntities(EIMSDataContext entityContext)
        {
            return entityContext.Departments.ToList();
        }

        protected override Department GetEntity(EIMSDataContext entityContext, int id)
        {
            return entityContext.Departments.Where(d => d.DepartmentId == id).FirstOrDefault();
        }
    }
}
