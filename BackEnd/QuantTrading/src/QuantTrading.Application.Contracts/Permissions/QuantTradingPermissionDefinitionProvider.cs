using QuantTrading.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace QuantTrading.Permissions;

public class QuantTradingPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(QuantTradingPermissions.GroupName);

        var booksPermission = myGroup.AddPermission(QuantTradingPermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(QuantTradingPermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(QuantTradingPermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(QuantTradingPermissions.Books.Delete, L("Permission:Books.Delete"));
        //Define your own permissions here. Example:
        //myGroup.AddPermission(QuantTradingPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<QuantTradingResource>(name);
    }
}
