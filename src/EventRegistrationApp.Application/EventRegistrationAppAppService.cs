using System;
using System.Collections.Generic;
using System.Text;
using EventRegistrationApp.Localization;
using Volo.Abp.Application.Services;

namespace EventRegistrationApp;

/* Inherit your application services from this class.
 */
public abstract class EventRegistrationAppAppService : ApplicationService
{
    protected EventRegistrationAppAppService()
    {
        LocalizationResource = typeof(EventRegistrationAppResource);
    }
}
