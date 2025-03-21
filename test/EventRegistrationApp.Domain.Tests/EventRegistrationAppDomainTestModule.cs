using Volo.Abp.Modularity;

namespace EventRegistrationApp;

[DependsOn(
    typeof(EventRegistrationAppDomainModule),
    typeof(EventRegistrationAppTestBaseModule)
)]
public class EventRegistrationAppDomainTestModule : AbpModule
{

}
