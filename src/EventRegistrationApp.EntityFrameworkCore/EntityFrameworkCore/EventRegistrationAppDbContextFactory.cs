using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EventRegistrationApp.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class EventRegistrationAppDbContextFactory : IDesignTimeDbContextFactory<EventRegistrationAppDbContext>
{
    public EventRegistrationAppDbContext CreateDbContext(string[] args)
    {
        EventRegistrationAppEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<EventRegistrationAppDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new EventRegistrationAppDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../EventRegistrationApp.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
