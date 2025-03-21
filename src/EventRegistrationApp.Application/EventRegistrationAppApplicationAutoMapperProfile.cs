using AutoMapper;
using EventRegistrationApp.Dtos.Events;
using EventRegistrationApp.Events;

namespace EventRegistrationApp;

public class EventRegistrationAppApplicationAutoMapperProfile : Profile
{
    public EventRegistrationAppApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Event, EventDto>();
        CreateMap<CreateUpdateEventDto, Event>();
        CreateMap<EventDto, CreateUpdateEventDto>();
    }
}
