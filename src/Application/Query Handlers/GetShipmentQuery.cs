using AutoMapper;
using Shipping.Application;
using Shipping.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Shipping.Shared;
using System.Linq;
using Shipping.Shared.Dto;
using Microsoft.Extensions.Caching.Memory;

namespace Shipping.Application.Lookups
{
    public class GetShipmentQuery : IRequest<ShipmentsDto>
    {
        public int Id { get; set; }
    }
    public class GetShipmentQueryHandler : IRequestHandler<GetShipmentQuery, ShipmentsDto>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
        private readonly IMemoryCache _cache;

        public GetShipmentQueryHandler(IMemoryCache cache, IMapper mapper, IApplicationDbContext context)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;

        }

        public async Task<ShipmentsDto> Handle(GetShipmentQuery request, CancellationToken cancellationToken)
        {
            var e = _context.Shipments.First(e => e.Id == request.Id);
            try
            {
                var item = new ShipmentsDto()
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
                return new ShipmentsDto();

            }


        }
    }

}
