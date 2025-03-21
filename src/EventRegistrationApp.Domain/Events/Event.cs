using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace EventRegistrationApp.Events
{
    public class Event : AuditedAggregateRoot<Guid>
    {
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public int Capacity { get; set; }
        public bool IsOnline { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid OrganizerId { get; set; }
        public string Link { get; set; }
        public string Location { get; set; }
        public bool IsActive { get; set; }
    }
}
