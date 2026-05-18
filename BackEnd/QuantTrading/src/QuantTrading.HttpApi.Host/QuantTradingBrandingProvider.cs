using Microsoft.Extensions.Localization;
using QuantTrading.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace QuantTrading;

[Dependency(ReplaceServices = true)]
public class QuantTradingBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<QuantTradingResource> _localizer;

    public QuantTradingBrandingProvider(IStringLocalizer<QuantTradingResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
