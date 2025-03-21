using EventRegistrationApp.Dtos.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EventRegistrationApp.Interface
{
    public interface IEventAppService :
        ICrudAppService< 
        EventDto, 
        Guid, 
        PagedAndSortedResultRequestDto, 
        CreateUpdateEventDto> 
    {

        Task<List<EventDto>> GetEventsAsync();
    }
}
