using EventRegistrationApp.Dtos.Events;
using EventRegistrationApp.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using System;

namespace EventRegistrationApp.Web.Pages.Events
{
    public class DetailsModel : EventRegistrationAppPageModel
    {
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        public EventDto Event { get; set; }

        private readonly IEventAppService _eventAppService;

        public DetailsModel(IEventAppService eventAppService)
        {
            _eventAppService = eventAppService;
        }

        public async Task OnGetAsync()
        {
            Event = await _eventAppService.GetAsync(Id);
        }
    }
}
