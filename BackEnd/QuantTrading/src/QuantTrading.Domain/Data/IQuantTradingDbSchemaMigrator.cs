using System.Threading.Tasks;

namespace QuantTrading.Data;

public interface IQuantTradingDbSchemaMigrator
{
    Task MigrateAsync();
}
