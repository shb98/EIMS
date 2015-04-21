using Core.Common.Data;

namespace EIMS.Data
{
    public abstract class DataRepositoryBase<T> : DataRepositoryBase<T, EIMSDataContext>
        where T : class, new()
    {
    }
}