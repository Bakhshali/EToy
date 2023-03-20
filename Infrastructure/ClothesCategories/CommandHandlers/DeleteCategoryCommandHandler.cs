using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Infrastructure.ClothesCategories.Commands;
using Infrastructure.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Infrastructure.ClothesCategories.CommandHandlers
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, OperationResult<Unit>>
    {
        private readonly AppDbContext _context;
        private readonly IPersistence _persistence;

        public DeleteCategoryCommandHandler(AppDbContext context,IPersistence persistence)
        {
            _context = context;
            _persistence = persistence;
        }

        public async Task<OperationResult<Unit>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Unit>();


            var category = await _context.Categories.Include(c => c.ClothesCategory)
            .SingleOrDefaultAsync(c => c.Id == request.Id, cancellationToken);


            if (category.ClothesCategory.Any())
            {
                return result.AddError("Could not delete position which has employee associated to it\nRemove employee from that position first!");
            }


            _context.Categories.Remove(category);

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
