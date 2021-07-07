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
    public class GetApprovedShipmentsQuery : IRequest<List<ApprovedShipmentsDto>>
    {
        public string Search { get; set; }
        public int Take { get; set; }
        public int Skip { get; set; }
    }
    public class GetApprovedShipmentsQueryHandler : IRequestHandler<GetApprovedShipmentsQuery, List<ApprovedShipmentsDto>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
        private readonly IMemoryCache _cache;

        public GetApprovedShipmentsQueryHandler(IMemoryCache cache, IMapper mapper, IApplicationDbContext context)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;

        }

        public async Task<List<ApprovedShipmentsDto>> Handle(GetApprovedShipmentsQuery request, CancellationToken cancellationToken)
        {
            var items = _context.Shipments.Where(e => e.Status == ShipmentStatus.Approved)
                .Select(e => new ApprovedShipmentsDto()
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
