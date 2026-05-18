using QuantTrading.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace QuantTrading.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class QuantTradingController : AbpControllerBase
{
    protected QuantTradingController()
    {
        LocalizationResource = typeof(QuantTradingResource);
    }
}
