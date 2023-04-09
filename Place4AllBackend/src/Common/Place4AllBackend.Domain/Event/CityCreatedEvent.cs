using Place4AllBackend.Domain.Common;
using Place4AllBackend.Domain.Entities;

namespace Place4AllBackend.Domain.Event
{
    public class CityCreatedEvent : DomainEvent
    {
        public CityCreatedEvent(City city)
        {
            City = city;
        }

        public City City { get; }
    }
}