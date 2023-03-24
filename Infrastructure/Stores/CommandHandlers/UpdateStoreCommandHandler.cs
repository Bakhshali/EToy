using AutoMapper;
using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Domain.Model;
using Infrastructure.Common;
using Infrastructure.Stores.Commands;
using Infrastructure.Stores.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Stores.CommandHandlers
{
    public class UpdateStoreCommandHandler : IRequestHandler<UpdateStoreCommand, OperationResult<GetStoreVm>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IPersistence _persistence;

        public UpdateStoreCommandHandler(AppDbContext context,IMapper mapper,IPersistence persistence)
        {
            _context = context;
            _mapper = mapper;
            _persistence = persistence;
        }
        public async Task<OperationResult<GetStoreVm>> Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<GetStoreVm>();

            if(request.Id != request.Model.Id)
            {
                return result.AddError(ErrorMessages.SourceCodeChange);
            }

            var store = await _context.Stores.AsNoTracking().SingleOrDefaultAsync(s => s.Id == request.Id, cancellationToken);

            if(store is null)
            {
                return result.AddError(ErrorMessages.EntityNotFound);
            }

            var updated = _mapper.Map<Store>(request.Model);

            _context.Stores.Update(updated);

            var persistenceResult = await _persistence.SaveChangesAsync();

            if(persistenceResult == 0)
            {
                return result.AddError(ErrorMessages.NotBeingAbleToUpdate);
            }

            result.Entity = _mapper.Map<GetStoreVm>(updated);
            return result;
        }
    }
}
