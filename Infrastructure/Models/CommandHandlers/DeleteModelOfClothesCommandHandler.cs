using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Infrastructure.Common;
using Infrastructure.Models.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Models.CommandHandlers
{
    public class DeleteModelOfClothesCommandHandler : IRequestHandler<DeleteModelOfClothesCommand, OperationResult<Unit>>
    {
        private readonly AppDbContext _context;
        private readonly IPersistence _persistence;

        public DeleteModelOfClothesCommandHandler(AppDbContext context,IPersistence persistence)
        {
            _context = context;
            _persistence = persistence;
        }
        public async Task<OperationResult<Unit>> Handle(DeleteModelOfClothesCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Unit>();

            var models = await _context.ModelOfClothes.Include(m => m.ClothesModel)
                .SingleOrDefaultAsync(m => m.Id == request.Id, cancellationToken);

            if (models.ClothesModel.Any())
            {
                return result.AddError("Could not delete store which has clothes associated to it\nRemove clothes from that store first!");
            }

            _context.ModelOfClothes.Remove(models);

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
