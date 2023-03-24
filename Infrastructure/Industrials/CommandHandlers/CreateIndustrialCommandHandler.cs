using AutoMapper;
using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Domain.Model;
using Infrastructure.Common;
using Infrastructure.Industrials.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Industrials.CommandHandlers
{
    public class CreateIndustrialCommandHandler : IRequestHandler<CreateIndustrialCommand, OperationResult<int>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IPersistence _persistence;

        public CreateIndustrialCommandHandler(AppDbContext context, IMapper mapper, IPersistence persistence)
        {
            _context = context;
            _mapper = mapper;
            _persistence = persistence;
        }

        public async Task<OperationResult<int>> Handle(CreateIndustrialCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<int>();

            var industrial = _mapper.Map<Industrial>(request);

            await _context.Industrials.AddAsync(industrial, cancellationToken);

            var persistence = await _persistence.SaveChangesAsync();

            if (persistence == 0)
            {

                return result.AddError(ErrorMessages.CouldNotAddToDatabase);
            }

            return result;
        }
    }
}
