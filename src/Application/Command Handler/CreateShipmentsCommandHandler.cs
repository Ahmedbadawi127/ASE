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
using Shipping.Domain.Enums;

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

            try
            {

                if (request.Id > 0)
                {
                    var c = _context.Shipments.First(e => e.Id == request.Id);


                    c.Name = request.ShipmentName ?? "";
                    c.ReceiverCityId = request.ReceiverCityId;
                    c.ReceiverCityName = request.ReceiverCityName;
                    c.ReceiverStateId = request.ReceiverStateId;
                    c.CustomerId = request.CustomerId;
                    c.ReceiverName = request.ReceiverName;
                    c.ReceiverPhone = request.ReceiverPhone;
                    c.Notes = request.Notes;
                    c.ReceiverStateName = request.ReceiverStateName;
                    c.Address = request.Address;
                    c.CashToBeCollected = request.CashToBeCollected;
                    c.Status = ShipmentStatus.Draft;

                    await _context.SaveChangesAsync(cancellationToken);

                    return c.Id;

                }
                else
                {
                    var entity = new Shipment
                    {
                        Name = request.ShipmentName ?? "",
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
                        Status = ShipmentStatus.Draft,
                    };

                    customer.Shipments.Add(entity);
                    await _context.SaveChangesAsync(cancellationToken);
                    return entity.Id;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
