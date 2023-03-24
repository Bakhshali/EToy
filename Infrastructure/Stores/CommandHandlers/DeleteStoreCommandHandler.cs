using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Infrastructure.Common;
using Infrastructure.Stores.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Stores.CommandHandlers
{
    public class DeleteStoreCommandHandler : IRequestHandler<DeleteStoreCommand, OperationResult<Unit>>
    {
        private readonly AppDbContext _context;
        private readonly IPersistence _persistence;

        public DeleteStoreCommandHandler(AppDbContext context,IPersistence persistence)
        {
            _context = context;
            _persistence = persistence;
        }
        public async Task<OperationResult<Unit>> Handle(DeleteStoreCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Unit>();

            var store = await _context.Stores.Include(s => s.ClothesStore).SingleOrDefaultAsync(s => s.Id == request.Id);

            if (store.ClothesStore.Any())
            {
                return result.AddError("Could not delete store which has clothes associated to it\nRemove clothes from that store first!");
            }

            _context.Stores.Remove(store);

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
