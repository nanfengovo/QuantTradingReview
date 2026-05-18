using Volo.Abp.Modularity;

namespace QuantTrading;

[DependsOn(
    typeof(QuantTradingDomainModule),
    typeof(QuantTradingTestBaseModule)
)]
public class QuantTradingDomainTestModule : AbpModule
{

}
