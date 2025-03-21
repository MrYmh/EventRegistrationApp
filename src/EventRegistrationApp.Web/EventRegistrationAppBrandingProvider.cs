using Microsoft.Extensions.Localization;
using EventRegistrationApp.Localization;
using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace EventRegistrationApp.Web;

[Dependency(ReplaceServices = true)]
public class EventRegistrationAppBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<EventRegistrationAppResource> _localizer;

    public EventRegistrationAppBrandingProvider(IStringLocalizer<EventRegistrationAppResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
