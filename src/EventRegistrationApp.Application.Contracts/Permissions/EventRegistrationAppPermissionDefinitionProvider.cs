using EventRegistrationApp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace EventRegistrationApp.Permissions;

public class EventRegistrationAppPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(EventRegistrationAppPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(EventRegistrationAppPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<EventRegistrationAppResource>(name);
    }
}
