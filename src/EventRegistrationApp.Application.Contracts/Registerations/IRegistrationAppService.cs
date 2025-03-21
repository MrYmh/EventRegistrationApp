using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace EventRegistrationApp.Registerations
{
    public interface IRegistrationAppService : IApplicationService
    {
        Task RegisterAsync(Guid eventId);
        Task CancelRegistrationAsync(Guid eventId);
    }
}
