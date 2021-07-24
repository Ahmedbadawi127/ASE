using Shipping.Domain.Entities;
using Shipping.Application.Common.Interfaces;
using Shipping.Application.Lookups;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Shipping.Shared.Commands.Geography.States;

namespace Shipping.Application.CommandHandler.States
{
    public class CreateStateCommandHandler : IRequestHandler<CreateStateCommand, int>
    {

        private readonly IApplicationDbContext _context;
        private readonly ILookupService _lookupService;

        public CreateStateCommandHandler
        (
             IApplicationDbContext context
            , ILookupService lookupService
        )
        {
            _lookupService = lookupService;
            _context = context;
        }
        public async Task<int> Handle(CreateStateCommand request, CancellationToken cancellationToken)
        {

            try
            {

                var entity = new State
                {
                    Name = request.Name,
                };

                await _context.States.AddAsync(entity);
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
