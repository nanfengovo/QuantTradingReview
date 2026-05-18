using Volo.Abp.Settings;

namespace QuantTrading.Settings;

public class QuantTradingSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(QuantTradingSettings.MySetting1));
    }
}
