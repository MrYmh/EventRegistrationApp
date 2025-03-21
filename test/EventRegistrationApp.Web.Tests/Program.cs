using Microsoft.AspNetCore.Builder;
using EventRegistrationApp;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();

builder.Environment.ContentRootPath = GetWebProjectContentRootPathHelper.Get("EventRegistrationApp.Web.csproj");
await builder.RunAbpModuleAsync<EventRegistrationAppWebTestModule>(applicationName: "EventRegistrationApp.Web" );

public partial class Program
{
}
