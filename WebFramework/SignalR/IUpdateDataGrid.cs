using Common.Interface;
using Kendo.DynamicLinqCore;

namespace WebFramework
{
    public interface IUpdateDataGrid : IScopedDependency
    {
        DataSourceResult GetUpdateSourceGrid(DataSourceRequest dataSourceRequest);
    }
}
