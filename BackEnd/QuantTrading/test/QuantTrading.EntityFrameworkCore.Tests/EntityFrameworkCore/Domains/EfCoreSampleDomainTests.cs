using QuantTrading.Samples;
using Xunit;

namespace QuantTrading.EntityFrameworkCore.Domains;

[Collection(QuantTradingTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<QuantTradingEntityFrameworkCoreTestModule>
{

}
