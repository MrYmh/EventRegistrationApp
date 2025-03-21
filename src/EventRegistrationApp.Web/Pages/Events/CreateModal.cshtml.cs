using EventRegistrationApp.Dtos.Events;
using EventRegistrationApp.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace EventRegistrationApp.Web.Pages.Events
{
    public class CreateModalModel : EventRegistrationAppPageModel
    {
        [BindProperty]
        public CreateUpdateEventDto Event { get; set; }

        private readonly IEventAppService _eventAppService;

        public CreateModalModel(IEventAppService eventAppService)
        {
            _eventAppService = eventAppService;
        }

        public void OnGet()
        {
            Event = new CreateUpdateEventDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _eventAppService.CreateAsync(Event);
            return NoContent();
        }
    }
}
