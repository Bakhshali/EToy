using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Infrastructure.Common;
using Infrastructure.Discounts.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Discounts.CommandHanlders
{
    public class DeleteDiscountCommandHandler : IRequestHandler<DeleteDiscountCommand, OperationResult<Unit>>
    {
        private readonly AppDbContext _context;
        private readonly IPersistence _persistence;

        public DeleteDiscountCommandHandler(AppDbContext context,IPersistence persistence)
        {
            _context = context;
            _persistence = persistence;
        }
        public async Task<OperationResult<Unit>> Handle(DeleteDiscountCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Unit>();

            var discount = await _context.Discounts.Include(d => d.ClothesDiscount).SingleOrDefaultAsync(d => d.Id == request.Id);

            if (discount.ClothesDiscount.Any())
            {
                return result.AddError("Could not delete store which has clothes associated to it\nRemove clothes from that store first!");
            }

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
