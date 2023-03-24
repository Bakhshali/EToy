using AutoMapper;
using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Domain.Model;
using Infrastructure.Common;
using Infrastructure.Discounts.Commands;
using Infrastructure.Discounts.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Discounts.CommandHanlders
{
    public class UpdateDiscountCommandHandler : IRequestHandler<UpdateDiscountCommand, OperationResult<GetDiscountVm>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IPersistence _persistence;

        public UpdateDiscountCommandHandler(AppDbContext context,IMapper mapper,IPersistence persistence)
        {
            _context = context;
            _mapper = mapper;
            _persistence = persistence;
        }
        public async Task<OperationResult<GetDiscountVm>> Handle(UpdateDiscountCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<GetDiscountVm>();

            if(request.Id != request.Model.Id)
            {
                return result.AddError(ErrorMessages.SourceCodeChange);
            }

            var discounts = await _context.Discounts.AsNoTracking()
                .SingleOrDefaultAsync(d => d.Id == request.Id);

            if(discounts is null)
            {
                return result.AddError(ErrorMessages.EntityNotFound);
            }

            var updated = _mapper.Map<Discount>(request.Model);

            _context.Discounts.Update(updated);

            var persistence = await _persistence.SaveChangesAsync();

            if(persistence == 0)
            {
                return result.AddError(ErrorMessages.NotBeingAbleToUpdate);
            }

            result.Entity = _mapper.Map<GetDiscountVm>(updated);

            return result;
        }
    }
}
