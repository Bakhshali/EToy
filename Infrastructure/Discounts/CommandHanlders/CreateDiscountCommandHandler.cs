using AutoMapper;
using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Domain.Model;
using Infrastructure.Common;
using Infrastructure.Discounts.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Discounts.CommandHanlders
{
    public class CreateDiscountCommandHandler : IRequestHandler<CreateDiscountCommand, OperationResult<Guid>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IPersistence _persistence;

        public CreateDiscountCommandHandler(AppDbContext context,IMapper mapper,IPersistence persistence)
        {
            _context = context;
            _mapper = mapper;
            _persistence = persistence;
        }
        public async Task<OperationResult<Guid>> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Guid>();

            var discount = _mapper.Map<Discount>(request);

            await _context.Discounts.AddAsync(discount, cancellationToken);

            var persistence = await _persistence.SaveChangesAsync();

            if(persistence == 0)
            {
                return result.AddError(ErrorMessages.CouldNotAddToDatabase);
            }

            return result;
        }
    }
}
