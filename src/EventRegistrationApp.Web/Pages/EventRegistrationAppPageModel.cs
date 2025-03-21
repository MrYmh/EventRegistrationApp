using EventRegistrationApp.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace EventRegistrationApp.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class EventRegistrationAppPageModel : AbpPageModel
{
    protected EventRegistrationAppPageModel()
    {
        LocalizationResourceType = typeof(EventRegistrationAppResource);
    }
}
