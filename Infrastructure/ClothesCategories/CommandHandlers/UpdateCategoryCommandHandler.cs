using AutoMapper;
using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Domain.Model;
using Infrastructure.ClothesCategories.Commands;
using Infrastructure.ClothesCategories.ViewModels;
using Infrastructure.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Infrastructure.ClothesCategories.CommandHandlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, OperationResult<GetCategoryVm>>
    {
        private readonly AppDbContext _context;
        private readonly IPersistence _persistence;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(AppDbContext context,IPersistence persistence,IMapper mapper)
        {
            _context = context;
            _persistence = persistence;
            _mapper = mapper;
        }

        public async Task<OperationResult<GetCategoryVm>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            
            var result = new OperationResult<GetCategoryVm>();

            if (request.Id != request.Model.Id)
            {
                return result.AddError(ErrorMessages.SourceCodeChange);
            }

            var category = await _context.Categories.AsNoTracking().SingleOrDefaultAsync(c => c.Id == request.Id,cancellationToken);

            if (category is null)
            {
                return result.AddError(ErrorMessages.EntityNotFound);
            }

            var update = _mapper.Map<CategoryOfClothes>(request.Model);

            _context.Categories.Update(update);

            var persistence = await _persistence.SaveChangesAsync();

            if (persistence == 0)
            {
                return result.AddError(ErrorMessages.NotBeingAbleToUpdate);
            }

            result.Entity = _mapper.Map<GetCategoryVm>(update);
            return result;
        }
    }
}
