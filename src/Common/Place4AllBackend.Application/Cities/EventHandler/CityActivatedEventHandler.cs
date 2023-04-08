using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Domain.Event;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Place4AllBackend.Application.Cities.EventHandler
{
    public class CityActivatedEventHandler : INotificationHandler<DomainEventNotification<CityActivatedEvent>>
    {
        private readonly ILogger<CityActivatedEventHandler> _logger;
        private readonly IEmailService _emailService;

        public CityActivatedEventHandler(ILogger<CityActivatedEventHandler> logger, IEmailService emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }

        public async Task Handle(DomainEventNotification<CityActivatedEvent> notification,
            CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("Place4AllBackend Place4AllBackend.Domain Event: {DomainEvent}",
                domainEvent.GetType().Name);

            if (domainEvent.City != null)
            {
                await _emailService.SendAsync(new EmailRequest
                {
                    Subject = domainEvent.City.Name + " is activated.",
                    Body = "City is activated successfully.",
                    FromDisplayName = "Clean Architecture",
                    FromMail = "test@test.com",
                    ToMail = new List<string> { "to@test.com" }
                });
            }
        }
    }
}