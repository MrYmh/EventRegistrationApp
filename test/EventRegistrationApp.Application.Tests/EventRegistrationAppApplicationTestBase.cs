using Volo.Abp.Modularity;

namespace EventRegistrationApp;

public abstract class EventRegistrationAppApplicationTestBase<TStartupModule> : EventRegistrationAppTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
