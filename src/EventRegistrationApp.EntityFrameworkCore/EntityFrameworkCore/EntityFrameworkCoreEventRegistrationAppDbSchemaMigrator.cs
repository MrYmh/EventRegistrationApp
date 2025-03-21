using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EventRegistrationApp.Data;
using Volo.Abp.DependencyInjection;

namespace EventRegistrationApp.EntityFrameworkCore;

public class EntityFrameworkCoreEventRegistrationAppDbSchemaMigrator
    : IEventRegistrationAppDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreEventRegistrationAppDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the EventRegistrationAppDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<EventRegistrationAppDbContext>()
            .Database
            .MigrateAsync();
    }
}
