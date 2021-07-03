using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Shipping.Shared.Dto;
using Microsoft.Extensions.Caching.Memory;

namespace Shipping.Application.Lookups
{
    public class GetLookupWithCategQuery : IRequest<List<LookupWithCategDto>>
    {
        public string LoggedInUser { get; set; }
        public string DataKey { get; set; }
        public string Id { get; set; }
        public int UserTypeId { get; set; }
        public int CategoryId { get; set; }
        public string Search { get; set; }
        public int Take { get; set; }
        public int Skip { get; set; }
    }
    public class GetLookupWithCategQueryHandler : IRequestHandler<GetLookupWithCategQuery, List<LookupWithCategDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILookupService _lookupService;
        private readonly IMemoryCache _cache;

        public GetLookupWithCategQueryHandler(IMemoryCache cache, IMapper mapper, ILookupService lookupService)
        {
            _lookupService = lookupService;
            _mapper = mapper;
            _cache = cache;

        }

        public async Task<List<LookupWithCategDto>> Handle(GetLookupWithCategQuery request, CancellationToken cancellationToken)
        {
            return await _lookupService.GetLookupsWithCateg
                (
                Key: request.DataKey
                ,Id: request.Id
                ,Search: request.Search
                ,UserTypeId: request.UserTypeId
                , CategoryId: request.CategoryId
                , LoggedInUser: request.LoggedInUser
                , Take:request.Take
                ,Skip:request.Skip
                , cancellationToken: cancellationToken);
        }
    }

}
