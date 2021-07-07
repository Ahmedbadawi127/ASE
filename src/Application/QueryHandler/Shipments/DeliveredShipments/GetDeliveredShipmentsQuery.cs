using AutoMapper;
using Shipping.Application.Common.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Shipping.Shared.Dto;
using Microsoft.Extensions.Caching.Memory;
using Shipping.Domain.Enums;

namespace Shipping.Application.QueryHandler.Shipments
{
    public class GetDeliveredShipmentsQuery : IRequest<List<DeliveredShipmentsDto>>
    {
        public string Search { get; set; }
        public int Take { get; set; }
        public int Skip { get; set; }
    }
    public class GetDeliveredShipmentsQueryHandler : IRequestHandler<GetDeliveredShipmentsQuery, List<DeliveredShipmentsDto>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
        private readonly IMemoryCache _cache;

        public GetDeliveredShipmentsQueryHandler(IMemoryCache cache, IMapper mapper, IApplicationDbContext context)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;

        }

        public async Task<List<DeliveredShipmentsDto>> Handle(GetDeliveredShipmentsQuery request, CancellationToken cancellationToken)
        {
            var items = _context.Shipments.Where(e=>e.Status == ShipmentStatus.Delivered)
                .Select(e => new DeliveredShipmentsDto()
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
                    CustomerName = e.Customer.NameAr,
                    Address = e.Address,
                    Status = e.Status,
                }
                ).ToList();


            return items;
        }
    }

}
