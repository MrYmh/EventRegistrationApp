using EventRegistrationApp.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace EventRegistrationApp.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class EventRegistrationAppController : AbpControllerBase
{
    protected EventRegistrationAppController()
    {
        LocalizationResource = typeof(EventRegistrationAppResource);
    }
}
