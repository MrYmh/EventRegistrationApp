using EventRegistrationApp.Dtos.Events;
using EventRegistrationApp.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using System;
using Volo.Abp.Domain.Repositories;
using EventRegistrationApp.Registrations;

namespace EventRegistrationApp.Web.Pages.Events
{
    public class DetailsModel : EventRegistrationAppPageModel
    {
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        public EventDto Event { get; set; }
        public bool IsUserRegistered { get; set; }

        private readonly IEventAppService _eventAppService;
        private readonly IRepository<Registration, Guid> _registrationRepository;

        public DetailsModel(IEventAppService eventAppService , IRepository<Registration, Guid> registrationRepository)
        {
            _eventAppService = eventAppService;
            _registrationRepository = registrationRepository;
        }

        public async Task OnGetAsync()
        {
            Event = await _eventAppService.GetAsync(Id);
            if (CurrentUser.IsAuthenticated)
            {
                var registration = await _registrationRepository.FirstOrDefaultAsync(r => r.EventId == Id && r.UserId == CurrentUser.Id);
                IsUserRegistered = registration != null;
            }
        }
    }
}
