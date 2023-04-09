using System.Threading.Tasks;
using Place4AllBackend.Domain.Common;

namespace Place4AllBackend.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}