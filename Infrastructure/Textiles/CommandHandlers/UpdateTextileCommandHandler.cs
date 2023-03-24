using AutoMapper;
using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Domain.Model;
using Infrastructure.Common;
using Infrastructure.Textiles.Commands;
using Infrastructure.Textiles.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Textiles.CommandHandlers
{
    public class UpdateTextileCommandHandler : IRequestHandler<UpdateTextileCommand, OperationResult<GetTextileVm>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IPersistence _persistence;

        public UpdateTextileCommandHandler(AppDbContext context,IMapper mapper,IPersistence persistence)
        {
            _context = context;
            _mapper = mapper;
            _persistence = persistence;
        }
        public async Task<OperationResult<GetTextileVm>> Handle(UpdateTextileCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<GetTextileVm>();

            if(request.Id != request.Model.Id)
            {
                return result.AddError(ErrorMessages.EntityNotFound);
            }

            var textile = await _context.Textiles.AsNoTracking().SingleOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

            if(textile is null)
            {
                return result.AddError(ErrorMessages.EntityNotFound);
            }

            var updated = _mapper.Map<Textile>(request.Model);

            _context.Textiles.Update(updated);

            var persistence = await _persistence.SaveChangesAsync();

            if(persistence == 0)
            {
                return result.AddError(ErrorMessages.NotBeingAbleToUpdate);
            }

            result.Entity = _mapper.Map<GetTextileVm>(updated);
            return result;
        }
    }
}
