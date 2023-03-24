using AutoMapper;
using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Domain.Model;
using Infrastructure.Common;
using Infrastructure.Models.Commands;
using Infrastructure.Models.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Models.CommandHandlers
{
    public class UpdateModelOfClothesCommandHandler : IRequestHandler<UpdateModelOfClothesCommand, OperationResult<GetModelOfClothesVm>>
    {
        private readonly IMapper _mapper;
        private readonly IPersistence _persistence;
        private readonly AppDbContext _context;

        public UpdateModelOfClothesCommandHandler(AppDbContext context,IMapper mapper,IPersistence persistence)
        {
            _mapper = mapper;
            _persistence = persistence;
            _context = context;
        }
        public async Task<OperationResult<GetModelOfClothesVm>> Handle(UpdateModelOfClothesCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<GetModelOfClothesVm>();

            if(request.Id != request.Model.Id)
            {
                return result.AddError(ErrorMessages.EntityNotFound);
            }

            var models = await _context.ModelOfClothes.AsNoTracking().SingleOrDefaultAsync(m => m.Id == request.Id, cancellationToken);

            if(models is null)
            {
                return result.AddError(ErrorMessages.EntityNotFound);
            }

            var updated = _mapper.Map<ModelOfClothes>(request.Model);

            _context.ModelOfClothes.Update(updated);

            var persistence = await _persistence.SaveChangesAsync();

            if(persistence == 0)
            {
                return result.AddError(ErrorMessages.NotBeingAbleToUpdate);
            }

            result.Entity = _mapper.Map<GetModelOfClothesVm>(updated);
            return result;
        }
    }
}
