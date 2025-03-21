using EventRegistrationApp.Dtos.Events;
using EventRegistrationApp.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using System;

namespace EventRegistrationApp.Web.Pages.Events
{
    public class EditModalModel : EventRegistrationAppPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateEventDto Event { get; set; }

        private readonly IEventAppService _eventAppService;

        public EditModalModel(IEventAppService eventAppService)
        {
            _eventAppService = eventAppService;
        }

        public async Task OnGetAsync()
        {
            var eventDto = await _eventAppService.GetAsync(Id);
            Event = ObjectMapper.Map<EventDto, CreateUpdateEventDto>(eventDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _eventAppService.UpdateAsync(Id, Event);
            return NoContent();
        }
    }
}
