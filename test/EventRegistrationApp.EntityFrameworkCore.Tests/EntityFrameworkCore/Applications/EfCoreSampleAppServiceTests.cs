using EventRegistrationApp.Samples;
using Xunit;

namespace EventRegistrationApp.EntityFrameworkCore.Applications;

[Collection(EventRegistrationAppTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<EventRegistrationAppEntityFrameworkCoreTestModule>
{

}
