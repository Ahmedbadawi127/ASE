using Shipping.Application.Common.Interfaces;
using Shipping.Application.Lookups;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Shipping.Shared.Commands.Geography.States;

namespace Shipping.Application.CommandHandler.States
{
    public class DeleteStateCommandHandler : IRequestHandler<DeleteStateCommand, int>
    {

        private readonly IApplicationDbContext _context;
        private readonly ILookupService _lookupService;

        public DeleteStateCommandHandler
        (
             IApplicationDbContext context
            , ILookupService lookupService
        )
        {
            _lookupService = lookupService;
            _context = context;
        }
        public async Task<int> Handle(DeleteStateCommand request, CancellationToken cancellationToken)
        {

            try
            {

                if (request.Id > 0)
                {

                    var c = await _context.States.FindAsync(request.Id);
                    if (c != null)
                    {
                        _context.States.Remove(c);
                        await _context.SaveChangesAsync(cancellationToken);
                        return c.Id;
                    }

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
