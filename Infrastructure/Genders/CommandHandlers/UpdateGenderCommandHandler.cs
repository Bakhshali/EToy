using AutoMapper;
using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Domain.Model;
using Infrastructure.ClothesCategories.ViewModels;
using Infrastructure.Common;
using Infrastructure.Genders.Commands;
using Infrastructure.Genders.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Genders.CommandHandlers
{
    public class UpdateGenderCommandHandler : IRequestHandler<UpdateGenderCommand, OperationResult<GetGenderVm>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IPersistence _persistence;

        public UpdateGenderCommandHandler(AppDbContext context,IMapper mapper,IPersistence persistence)
        {
            _context = context;
            _mapper = mapper;
            _persistence = persistence;
        }

        public async Task<OperationResult<GetGenderVm>> Handle(UpdateGenderCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<GetGenderVm>();

            if (request.Id != request.Model.Id)
            {
                return result.AddError(ErrorMessages.SourceCodeChange);
            }

            var gender = await _context.Genders.AsNoTracking().SingleOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (gender == null)
            {
                return result.AddError(ErrorMessages.EntityNotFound);
            }

            var update = _mapper.Map<Gender>(request.Model);

            _context.Genders.Update(update);

            var persistence = await _persistence.SaveChangesAsync();

            if (persistence == 0)
            {
                return result.AddError(ErrorMessages.NotBeingAbleToUpdate);
            }

            result.Entity = _mapper.Map<GetGenderVm>(update);
            return result;
        }
    }
}
