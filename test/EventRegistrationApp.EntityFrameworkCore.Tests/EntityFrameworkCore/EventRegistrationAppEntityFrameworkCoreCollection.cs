﻿using Xunit;

namespace EventRegistrationApp.EntityFrameworkCore;

[CollectionDefinition(EventRegistrationAppTestConsts.CollectionDefinitionName)]
public class EventRegistrationAppEntityFrameworkCoreCollection : ICollectionFixture<EventRegistrationAppEntityFrameworkCoreFixture>
{

}
