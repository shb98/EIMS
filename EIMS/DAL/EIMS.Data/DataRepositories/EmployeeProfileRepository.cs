using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Linq;
using Core.Common.Utils;

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

        protected override Employee UpdateEntity(EIMSDataContext entityContext, Employee entity)
        {
            return (from e in entityContext.Employees
                where e.EmployeeId == entity.EmployeeId
                select e).FirstOrDefault();
        }

        protected override IEnumerable<Employee> GetEntities(EIMSDataContext entityContext)
        {
            return (from e in entityContext.Employees
                select e).Include(e=>e.Department);
        }

        protected override Employee GetEntity(EIMSDataContext entityContext, int id)
        {
            var query = (from e in entityContext.Employees
                where e.EmployeeId == id
                select e).Include(e=>e.Department);

            var results = query.FirstOrDefault();

            return results;
        }

        // Title and department can only updated by HR or admin
        public Employee UpdateBasicProfileInfo(Employee employee)
        {
            using (var entityContext = new EIMSDataContext())
            {
                var existingEntity = UpdateEntity(entityContext, employee);

                SimpleMapper.PropertyMap(employee, existingEntity, new List<string>()
                {
                    "Title",
                    "Department"
                });

                entityContext.SaveChanges();
                return existingEntity;
            }
        }



        // Title and department can only updated by HR or admin
        public Employee UpdateFullProfileInfo(Employee employee)
        {
            using (var entityContext = new EIMSDataContext())
            {
                var existingEntity = UpdateEntity(entityContext, employee);

                SimpleMapper.PropertyMap(employee, existingEntity, new List<string>()
                {
                    "Title",
                    "Department"
                });
                if (employee.Department != null)
                {
                    existingEntity.Department = entityContext.Departments.First(d => d.DepartmentId == employee.Department.DepartmentId);
                }

                entityContext.SaveChanges();
                return existingEntity;
            }
        }
    }
}