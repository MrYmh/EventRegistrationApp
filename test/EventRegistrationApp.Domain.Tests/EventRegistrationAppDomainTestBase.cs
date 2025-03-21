using Volo.Abp.Modularity;

namespace EventRegistrationApp;

/* Inherit from this class for your domain layer tests. */
public abstract class EventRegistrationAppDomainTestBase<TStartupModule> : EventRegistrationAppTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
