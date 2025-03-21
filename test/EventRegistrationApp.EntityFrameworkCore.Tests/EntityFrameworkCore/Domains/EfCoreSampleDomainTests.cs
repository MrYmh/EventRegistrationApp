using EventRegistrationApp.Samples;
using Xunit;

namespace EventRegistrationApp.EntityFrameworkCore.Domains;

[Collection(EventRegistrationAppTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<EventRegistrationAppEntityFrameworkCoreTestModule>
{

}
