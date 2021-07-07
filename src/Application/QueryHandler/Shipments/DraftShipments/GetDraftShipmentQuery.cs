using AutoMapper;
using Shipping.Application.Common.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Shipping.Shared.Dto;
using Microsoft.Extensions.Caching.Memory;

namespace Shipping.Application.QueryHandler.Shipments
{
    public class GetDraftShipmentQuery : IRequest<DraftShipmentsDto>
    {
        public int Id { get; set; }
    }
    public class GetDraftShipmentQueryHandler : IRequestHandler<GetDraftShipmentQuery, DraftShipmentsDto>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
        private readonly IMemoryCache _cache;

        public GetDraftShipmentQueryHandler(IMemoryCache cache, IMapper mapper, IApplicationDbContext context)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;

        }

        public async Task<DraftShipmentsDto> Handle(GetDraftShipmentQuery request, CancellationToken cancellationToken)
        {
            var e = _context.Shipments.First(e => e.Id == request.Id);
            try
            {
                var item = new DraftShipmentsDto()
                {
                    Id = e.Id,
                    CashToBeCollected = e.CashToBeCollected,
                    CustomerId = e.CustomerId,
                    Notes = e.Notes,
                    ReceiverCityId = e.ReceiverCityId,
                    ReceiverCityName = e.ReceiverCityName,
                    ReceiverName = e.ReceiverName,
                    ReceiverPhone = e.ReceiverPhone,
                    ReceiverStateId = e.ReceiverStateId,
                    ReceiverStateName = e.ReceiverStateName,
                    ShipmentName = e.Name,
                    Address = e.Address,
                    Status = e.Status,
                };

                return item;


            }
            catch (Exception ex)
            {

                throw;
                return new DraftShipmentsDto();

            }


        }
    }

}
