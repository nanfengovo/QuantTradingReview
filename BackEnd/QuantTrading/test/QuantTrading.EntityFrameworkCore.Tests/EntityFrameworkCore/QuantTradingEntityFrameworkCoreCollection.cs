using Xunit;

namespace QuantTrading.EntityFrameworkCore;

[CollectionDefinition(QuantTradingTestConsts.CollectionDefinitionName)]
public class QuantTradingEntityFrameworkCoreCollection : ICollectionFixture<QuantTradingEntityFrameworkCoreFixture>
{

}
