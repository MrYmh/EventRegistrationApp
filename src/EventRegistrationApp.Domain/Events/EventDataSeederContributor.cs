using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace EventRegistrationApp.Events
{
    public class EventDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Event, Guid> _eventRepository;
        public EventDataSeederContributor(IRepository<Event, Guid> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _eventRepository.GetCountAsync() <= 0)
            {
                await _eventRepository.InsertAsync(
                    new Event
                    {
                        Capacity = 1,
                        IsActive = false,
                        IsOnline = true,
                        Link = "tesst",
                        NameAr = "test ar",
                        NameEn = "test en",
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now,
                        OrganizerId = new Guid("D7AF5D29-123C-476A-499A-3A18C9A8776B"),
                        Location = "test"
                    },
                    autoSave: true
                );

                //await _eventRepository.InsertAsync(
                //    new Book
                //    {
                //        Name = "The Hitchhiker's Guide to the Galaxy",
                //        Type = BookType.ScienceFiction,
                //        PublishDate = new DateTime(1995, 9, 27),
                //        Price = 42.0f
                //    },
                //    autoSave: true
                //);
            }
        }
    }
}
