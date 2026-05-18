using Volo.Abp.Modularity;

namespace QuantTrading;

/* Inherit from this class for your domain layer tests. */
public abstract class QuantTradingDomainTestBase<TStartupModule> : QuantTradingTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
