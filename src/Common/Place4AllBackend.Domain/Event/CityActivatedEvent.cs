using Place4AllBackend.Domain.Common;
using Place4AllBackend.Domain.Entities;

namespace Place4AllBackend.Domain.Event
{
    public class CityActivatedEvent : DomainEvent
    {
        public CityActivatedEvent(City city)
        {
            City = city;
        }

        public City City { get; }
    }
}