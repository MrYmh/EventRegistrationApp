using Volo.Abp.Settings;

namespace EventRegistrationApp.Settings;

public class EventRegistrationAppSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(EventRegistrationAppSettings.MySetting1));
    }
}
