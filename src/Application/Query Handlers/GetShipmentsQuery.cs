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
    public class GetShipmentsQuery : IRequest<List<ShipmentsDto>>
    {
        public string Search { get; set; }
        public int Take { get; set; }
        public int Skip { get; set; }
    }
    public class GetShipmentsQueryHandler : IRequestHandler<GetShipmentsQuery, List<ShipmentsDto>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
        private readonly IMemoryCache _cache;

        public GetShipmentsQueryHandler(IMemoryCache cache, IMapper mapper, IApplicationDbContext context)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;

        }

        public async Task<List<ShipmentsDto>> Handle(GetShipmentsQuery request, CancellationToken cancellationToken)
        {
            var items = _context.Shipments.
                Select(e => new ShipmentsDto()
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

            //if (!string.IsNullOrEmpty(request.Search))
            //{
            //    return items.Where(i => i.NameAr.ToLower().Contains(request.Search.ToLower()) || i.NameEn.ToLower().Contains(request.Search.ToLower())).ToList();
            //}
            //if (request.Take > 0)
            //{
            //    return items.OrderBy(i => i.NameAr).Take(request.Take).ToList();
            //}


            return items;
        }
    }

}
