using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace EventRegistrationApp.Registrations
{
    public class Registration : AuditedAggregateRoot<Guid>
    {
        public Guid EventId { get; set; }
        public Guid UserId { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
