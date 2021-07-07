using Shipping.Domain.Entities;
using Shipping.Application.Common.Interfaces;
using Shipping.Application.Lookups;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Shipping.Domain.Enums;
using Shipping.Shared.Commands.Shipments;

namespace Shipping.Application.CommandHandler.Shipments
{
    public class CreateDraftShipmentCommandHandler : IRequestHandler<CreateDraftShipmentCommand, int>
    {

        private readonly IApplicationDbContext _context;
        private readonly ILookupService _lookupService;

        public CreateDraftShipmentCommandHandler
        (
             IApplicationDbContext context
            , ILookupService lookupService
        )
        {
            _lookupService = lookupService;
            _context = context;
        }
        public async Task<int> Handle(CreateDraftShipmentCommand request, CancellationToken cancellationToken)
        {

            try
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

                await _context.Shipments.AddAsync(entity);
                await _context.SaveChangesAsync(cancellationToken);
                return entity.Id;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
