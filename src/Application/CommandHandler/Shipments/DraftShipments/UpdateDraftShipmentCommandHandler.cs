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
    public class UpdateDraftShipmentCommandHandler : IRequestHandler<UpdateDraftShipmentCommand, int>
    {

        private readonly IApplicationDbContext _context;
        private readonly ILookupService _lookupService;

        public UpdateDraftShipmentCommandHandler
        (
             IApplicationDbContext context
            , ILookupService lookupService
        )
        {
            _lookupService = lookupService;
            _context = context;
        }
        public async Task<int> Handle(UpdateDraftShipmentCommand request, CancellationToken cancellationToken)
        {

            try
            {

                if (request.Id > 0)
                {

                    var c = await _context.Shipments.FindAsync(request.Id);

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

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return 0;

        }
    }
}
