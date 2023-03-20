using AutoMapper;
using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Domain.Model;
using Infrastructure.Common;
using Infrastructure.Industrials.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Industrials.CommandHandlers
{
    public class DeleteIndustrialCommandHandler : IRequestHandler<DeleteIndustrialCommand, OperationResult<Unit>>
    {
        private readonly AppDbContext _context;
        private readonly IPersistence _persistence;

        public DeleteIndustrialCommandHandler(AppDbContext context, IPersistence persistence)
        {
            _context = context;
            _persistence = persistence;
        }

        public async Task<OperationResult<Unit>> Handle(DeleteIndustrialCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Unit>();

            var industrial = await _context.Industrials.Include(c => c.ClothesIndustrial).SingleOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (industrial.ClothesIndustrial.Any())
            {
                return result.AddError("Could not delete position which has employee associated to it\nRemove employee from that position first!");
            }

            _context.Industrials.Remove(industrial);

            var persistenceResult = await _persistence.SaveChangesAsync();
            if (persistenceResult == 0)
            {
                return result.AddError(ErrorMessages.CouldNotDelete);
            }

            result.Entity = Unit.Value;
            return result;
        }
    }
}
