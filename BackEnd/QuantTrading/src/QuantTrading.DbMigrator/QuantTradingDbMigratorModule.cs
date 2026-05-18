using QuantTrading.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace QuantTrading.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(QuantTradingEntityFrameworkCoreModule),
    typeof(QuantTradingApplicationContractsModule)
)]
public class QuantTradingDbMigratorModule : AbpModule
{
}
