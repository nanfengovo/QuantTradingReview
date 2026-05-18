using QuantTrading.Localization;
using Volo.Abp.Application.Services;

namespace QuantTrading;

/* Inherit your application services from this class.
 */
public abstract class QuantTradingAppService : ApplicationService
{
    protected QuantTradingAppService()
    {
        LocalizationResource = typeof(QuantTradingResource);
    }
}
