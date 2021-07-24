using AutoMapper;
using Shipping.Application.Common.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Shipping.Shared.Dto;
using Microsoft.Extensions.Caching.Memory;

namespace Shipping.Application.QueryHandler.Geography.States
{
    public class GetStatesQuery : IRequest<List<LookupDto>>
    {
        public string Search { get; set; }
        public int Take { get; set; }
        public int Skip { get; set; }
    }
    public class GetStatesQueryHandler : IRequestHandler<GetStatesQuery, List<LookupDto>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
        private readonly IMemoryCache _cache;

        public GetStatesQueryHandler(IMemoryCache cache, IMapper mapper, IApplicationDbContext context)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;

        }

        public async Task<List<LookupDto>> Handle(GetStatesQuery request, CancellationToken cancellationToken)
        {
            var items = _context.States.
                Select(e => new LookupDto()
                {
                    Id = e.Id,
                    DisplayName = e.Name,
                }
                ).ToList();

            if (!string.IsNullOrEmpty(request.Search))
            {
                return items.Where(i => i.DisplayName.ToLower().Contains(request.Search.ToLower())).ToList();
            }
            if (request.Take > 0)
            {
                return items.OrderBy(i => i.DisplayName).Take(request.Take).ToList();
            }


            return items;
        }
    }

}
