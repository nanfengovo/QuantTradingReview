using QuantTrading.Samples;
using Xunit;

namespace QuantTrading.EntityFrameworkCore.Applications;

[Collection(QuantTradingTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<QuantTradingEntityFrameworkCoreTestModule>
{

}
