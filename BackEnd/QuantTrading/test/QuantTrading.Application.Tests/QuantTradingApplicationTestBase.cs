using Volo.Abp.Modularity;

namespace QuantTrading;

public abstract class QuantTradingApplicationTestBase<TStartupModule> : QuantTradingTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
