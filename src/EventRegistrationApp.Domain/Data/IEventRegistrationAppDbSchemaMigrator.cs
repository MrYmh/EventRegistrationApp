using System.Threading.Tasks;

namespace EventRegistrationApp.Data;

public interface IEventRegistrationAppDbSchemaMigrator
{
    Task MigrateAsync();
}
