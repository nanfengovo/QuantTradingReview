using QuantTrading.Books;
using Xunit;

namespace QuantTrading.EntityFrameworkCore.Applications.Books;

[Collection(QuantTradingTestConsts.CollectionDefinitionName)]
public class EfCoreBookAppService_Tests : BookAppService_Tests<QuantTradingEntityFrameworkCoreTestModule>
{

}