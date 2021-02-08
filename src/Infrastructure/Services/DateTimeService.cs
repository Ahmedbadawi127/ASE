using Shipping.Application.Common.Interfaces;
using System;

namespace Shipping.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
