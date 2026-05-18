using Volo.Abp.Modularity;

namespace QuantTrading;

[DependsOn(
    typeof(QuantTradingApplicationModule),
    typeof(QuantTradingDomainTestModule)
)]
public class QuantTradingApplicationTestModule : AbpModule
{

}
