using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace QuantTrading.Data;

/* This is used if database provider does't define
 * IQuantTradingDbSchemaMigrator implementation.
 */
public class NullQuantTradingDbSchemaMigrator : IQuantTradingDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
