using EventRegistrationApp.Dtos.Events;
using EventRegistrationApp.Events;
using EventRegistrationApp.Interface;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace EventRegistrationApp.Services
{
    [Authorize(Roles = "admin")]
    public class EventAppService :
         CrudAppService<
        Event,
        EventDto, 
        Guid, 
        PagedAndSortedResultRequestDto, 
        CreateUpdateEventDto>, 
    IEventAppService 
    {
        //private readonly IRepository<Event, Guid> _eventRepository;

        public EventAppService(IRepository<Event, Guid> eventRepository) : base(eventRepository)
        {
           
        }

        public override Task<EventDto> CreateAsync(CreateUpdateEventDto input)
        {
            input.OrganizerId = CurrentUser.Id.Value;
            return base.CreateAsync(input);
        }

        public override async Task<EventDto> UpdateAsync(Guid id, CreateUpdateEventDto input)
        {
            var eventEntity = await Repository.GetAsync(id);

            // Only the organizer can update the event
            if (eventEntity.OrganizerId != CurrentUser.Id)
            {
                throw new UnauthorizedAccessException("You are not authorized to update this event.");
            }

            return await base.UpdateAsync(id, input);
        }

        public override async Task DeleteAsync(Guid id)
        {
            var eventEntity = await Repository.GetAsync(id);

            // Only the organizer can delete the event
            if (eventEntity.OrganizerId != CurrentUser.Id)
            {
                throw new UnauthorizedAccessException("You are not authorized to delete this event.");
            }

            await base.DeleteAsync(id);
        }

        //public override Task<PagedResultDto<EventDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        //{
        //    var x = base.GetListAsync(input);
        //    return base.GetListAsync(input);
        //}
        public async Task<List<EventDto>> GetEventsAsync()
        {
            var query = await Repository.GetQueryableAsync();

            if (CurrentUser.IsInRole("admin"))
            {
                // Admins can see all events (active and inactive)
                query = query.Where(e => e.OrganizerId == CurrentUser.Id);
            }
            else
            {
                // Non-admin users can only see active events
                query = query.Where(e => e.IsActive);
            }

            var events = await AsyncExecuter.ToListAsync(query);
            return ObjectMapper.Map<List<Event>, List<EventDto>>(events);
        }
        public override async Task<PagedResultDto<EventDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            // Get the base query
            var query = await Repository.GetQueryableAsync();

            // Apply filters based on user role
            if (CurrentUser.IsInRole("admin"))
            {
                // Admins can see all their events (active and inactive)
                query = query.Where(e => e.OrganizerId == CurrentUser.Id);
            }
            else
            {
                // Non-admin users can only see active events
                query = query.Where(e => e.IsActive);
            }

            // Apply sorting
            if (!input.Sorting.IsNullOrWhiteSpace())
            {
                query = query.OrderBy(input.Sorting);
            }

            // Apply pagination
            var totalCount = await AsyncExecuter.CountAsync(query);
            query = query.PageBy(input);

            // Execute the query and map the results
            var events = await AsyncExecuter.ToListAsync(query);
            var eventDtos = ObjectMapper.Map<List<Event>, List<EventDto>>(events);

            // Return the paged result
            return new PagedResultDto<EventDto>(totalCount, eventDtos);
        }
        //get all active events

        //get all user events if active or not
    }
}
