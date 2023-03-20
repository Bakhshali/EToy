using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Infrastructure.Common;
using Infrastructure.Genders.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Genders.CommandHandlers
{
    public class DeleteGenderCommandHandler : IRequestHandler<DeleteGenderCommand, OperationResult<Unit>>
    {
        private readonly AppDbContext _context;
        private readonly IPersistence _persistence;

        public DeleteGenderCommandHandler(AppDbContext context, IPersistence persistence)
        {
            _context = context;
            _persistence = persistence;
        }
        public async Task<OperationResult<Unit>> Handle(DeleteGenderCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Unit>();

            var gender = await _context.Genders.Include(c => c.ClothesGender).SingleOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (gender.ClothesGender.Any())
            {
                return result.AddError("Could not delete position which has employee associated to it\nRemove employee from that position first!");
            }

            _context.Genders.Remove(gender);

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
