using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace EventRegistrationApp.Data;

/* This is used if database provider does't define
 * IEventRegistrationAppDbSchemaMigrator implementation.
 */
public class NullEventRegistrationAppDbSchemaMigrator : IEventRegistrationAppDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
