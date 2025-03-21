using EventRegistrationApp.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace EventRegistrationApp.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(EventRegistrationAppEntityFrameworkCoreModule),
    typeof(EventRegistrationAppApplicationContractsModule)
    )]
public class EventRegistrationAppDbMigratorModule : AbpModule
{
}
