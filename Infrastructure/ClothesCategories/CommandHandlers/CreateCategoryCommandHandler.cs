using AutoMapper;
using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Domain.Model;
using Infrastructure.ClothesCategories.Commands;
using Infrastructure.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ClothesCategories.CommandHandlers
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, OperationResult<int>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IPersistence _persistence;

        public CreateCategoryCommandHandler(AppDbContext context,IMapper mapper,IPersistence persistence)
        {
            _context = context;
            _mapper = mapper;
            _persistence = persistence;
        }
        public async Task<OperationResult<int>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<int>();

            var category = _mapper.Map<CategoryOfClothes>(request);

            await _context.Categories.AddAsync(category,cancellationToken);

            var persistence = await _persistence.SaveChangesAsync();

            if (persistence == 0)
            {
                return result.AddError(ErrorMessages.CouldNotAddToDatabase);
            }

            //result.Entity = category.Id;

            return result;
        }
    }
}
