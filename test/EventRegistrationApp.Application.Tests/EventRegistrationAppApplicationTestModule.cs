using Volo.Abp.Modularity;

namespace EventRegistrationApp;

[DependsOn(
    typeof(EventRegistrationAppApplicationModule),
    typeof(EventRegistrationAppDomainTestModule)
)]
public class EventRegistrationAppApplicationTestModule : AbpModule
{

}
