using Shipping.Domain.Entities;
using Shipping.Application.Common.Exceptions;
using Shipping.Application.Common.Interfaces;
using Shipping.Shared;
using Shipping.Shared.Commands;
using Shipping.Shared.Dto;
using Shipping.Application.Lookups;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Collections.Generic;

namespace Shipping.Application.CreateFlowCommands
{
    public class CreateShipmentsCommandHandler : IRequestHandler<CreateShipmentsCommand, int>
    {

        private readonly IApplicationDbContext _context;
        private readonly ILookupService _lookupService;

        public CreateShipmentsCommandHandler
        (
             IApplicationDbContext context
            , ILookupService lookupService
        )
        {
            _lookupService = lookupService;
            _context = context;
        }


        public async Task<int> Handle(CreateShipmentsCommand request, CancellationToken cancellationToken)
        {
            var customer = _context.Customers.SingleOrDefault(u => u.Id == request.CustomerId);

            if (customer == null)
            {
                throw new NotFoundException(nameof(customer), request.CustomerId);
            }

            var entity = new Shipment
            {
                Name = request.ShipmentName,
                ReceiverCityId = request.ReceiverCityId,
                ReceiverCityName = request.ReceiverCityName,
                ReceiverStateId = request.ReceiverStateId,
                CustomerId = request.CustomerId,
                ReceiverName = request.ReceiverName,
                ReceiverPhone = request.ReceiverPhone,
                Notes = request.Notes,
                ReceiverStateName = request.ReceiverStateName,
                Address = request.Address,
                CashToBeCollected = request.CashToBeCollected,
            };

            try
            {
                customer.Shipments.Add(entity);
                await _context.SaveChangesAsync(cancellationToken);
                return entity.Id;

            }
            catch (Exception e)
            {
                customer.Shipments.Remove(entity);
                throw e;
            }

        }
    }
}
