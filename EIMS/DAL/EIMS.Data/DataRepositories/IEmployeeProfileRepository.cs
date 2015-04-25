using Core.Common.Contracts;

namespace EIMS.Data.DataRepositories
{
    public interface IEmployeeProfileRepository : IDataRepository<Employee>
    {
        Employee UpdateBasicProfileInfo(Employee employee);
    }
}