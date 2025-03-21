using System.Threading.Tasks;
using EventRegistrationApp.Localization;
using EventRegistrationApp.MultiTenancy;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace EventRegistrationApp.Web.Menus;

public class EventRegistrationAppMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<EventRegistrationAppResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                EventRegistrationAppMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);

        context.Menu.AddItem(
    new ApplicationMenuItem(
        "Events",
        l["Menu:Events"],
        icon: "fa fa-book"
    ).AddItem(
        new ApplicationMenuItem(
            "Events.Event",
            l["Menu:Event"],
            url: "/Events"
        )
    )
);


        return Task.CompletedTask;
    }
}
