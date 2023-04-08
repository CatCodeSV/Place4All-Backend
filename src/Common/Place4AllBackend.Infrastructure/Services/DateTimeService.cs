using System;
using Place4AllBackend.Application.Common.Interfaces;

namespace Place4AllBackend.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}