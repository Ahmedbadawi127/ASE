using AutoMapper;
using Shipping.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Shipping.Shared.Dto;
using Microsoft.Extensions.Caching.Memory;

namespace Shipping.Application.QueryHandler.Geography.States
{
    public class GetStateQuery : IRequest<LookupDto>
    {
        public int Id { get; set; }
    }
    public class GetStateQueryHandler : IRequestHandler<GetStateQuery, LookupDto>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
        private readonly IMemoryCache _cache;

        public GetStateQueryHandler(IMemoryCache cache, IMapper mapper, IApplicationDbContext context)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;

        }

        public async Task<LookupDto> Handle(GetStateQuery request, CancellationToken cancellationToken)
        {
            var e = _context.States.First(e => e.Id == request.Id);
            var item = new LookupDto()
            {
                Id = e.Id,
                DisplayName = e.Name,
            };


            return item;
        }
    }

}
