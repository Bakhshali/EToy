using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Infrastructure.Common;
using Infrastructure.Textiles.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Textiles.CommandHandlers
{
    public class DeleteTextileCommandHandler : IRequestHandler<DeleteTextileCommand, OperationResult<Unit>>
    {
        private readonly AppDbContext _context;
        private readonly IPersistence _persistence;

        public DeleteTextileCommandHandler(AppDbContext context,IPersistence persistence)
        {
            _context = context;
            _persistence = persistence;
        }
        public async Task<OperationResult<Unit>> Handle(DeleteTextileCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Unit>();

            var textile = await _context.Textiles.Include(t => t.ClothesTextile).SingleOrDefaultAsync(t => t.Id == request.Id);

            if (textile.ClothesTextile.Any())
            {
                return result.AddError("Could not delete store which has clothes associated to it\nRemove clothes from that store first!");
            }

            _context.Textiles.Remove(textile);

            var persistence = await _persistence.SaveChangesAsync();

            if(persistence == 0)
            {
                return result.AddError(ErrorMessages.CouldNotDelete);
            }

            result.Entity = Unit.Value;
            return result;
        }
    }
}
