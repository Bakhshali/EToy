using AutoMapper;
using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Domain.Model;
using Infrastructure.Common;
using Infrastructure.Genders.ViewModels;
using Infrastructure.Industrials.Commands;
using Infrastructure.Industrials.ViewModels;
using MediatR;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Industrials.CommandHandlers
{
    public class UpdateIndustrialCommandHandler : IRequestHandler<UpdateIndustrialCommand, OperationResult<GetIndustrialVm>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IPersistence _persistence;

        public UpdateIndustrialCommandHandler(AppDbContext context, IMapper mapper, IPersistence persistence)
        {
            _context = context;
            _mapper = mapper;
            _persistence = persistence;
        }

        public async Task<OperationResult<GetIndustrialVm>> Handle(UpdateIndustrialCommand request, CancellationToken cancellationToken)
        {

            var result = new OperationResult<GetIndustrialVm>();

            if (request.Id != request.Model.Id)
            {
                return result.AddError(ErrorMessages.SourceCodeChange);
            }

            var industrial = await _context.Industrials.AsNoTracking().SingleOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (industrial == null)
            {
                return result.AddError(ErrorMessages.EntityNotFound);
            }

            var update = _mapper.Map<Industrial>(request.Model);

            _context.Industrials.Update(update);

            var persistence = await _persistence.SaveChangesAsync();

            if (persistence == 0)
            {
                return result.AddError(ErrorMessages.NotBeingAbleToUpdate);
            }

            result.Entity = _mapper.Map<GetIndustrialVm>(update);
            return result;
        }
    }
}
