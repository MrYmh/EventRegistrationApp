using EventRegistrationApp.Events;
using EventRegistrationApp.Registerations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace EventRegistrationApp.Registrations
{
    [Route("api/app/registration")]
    public class RegistrationAppService : EventRegistrationAppAppService, IRegistrationAppService
    {
        private readonly IRepository<Registration, Guid> _registrationRepository;
        private readonly IRepository<Event, Guid> _eventRepository;

        public RegistrationAppService(
            IRepository<Registration, Guid> registrationRepository,
            IRepository<Event, Guid> eventRepository)
        {
            _registrationRepository = registrationRepository;
            _eventRepository = eventRepository;
        }

        [HttpPost("register")]
        public async Task RegisterAsync(Guid eventId)
        {
            var eventEntity = await _eventRepository.GetAsync(eventId);

            // Check if the event is active
            if (!eventEntity.IsActive)
            {
                throw new Exception("This event is not active.");
            }

            // Check if there is available capacity
            var registrations = await _registrationRepository.GetListAsync(r => r.EventId == eventId);
            if (registrations.Count >= eventEntity.Capacity)
            {
                throw new Exception("This event is full.");
            }

            // Register the user
            var registration = new Registration
            {
                EventId = eventId,
                UserId = CurrentUser.Id.Value,
                RegistrationDate = DateTime.Now
            };

            await _registrationRepository.InsertAsync(registration);
        }

        [HttpPost("cancel")]
        public async Task CancelRegistrationAsync(Guid eventId)
        {
            var eventEntity = await _eventRepository.GetAsync(eventId);

            // Check if the event has started
            if (eventEntity.StartDate <= DateTime.Now.AddHours(1))
            {
                throw new Exception("You cannot cancel registration within 1 hour of the event start time.");
            }

            // Find and delete the registration
            var registration = await _registrationRepository.FirstOrDefaultAsync(r => r.EventId == eventId && r.UserId == CurrentUser.Id.Value);
            if (registration != null)
            {
                await _registrationRepository.DeleteAsync(registration);
            }
        }
    }
}
