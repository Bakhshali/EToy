using AutoMapper;
using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Domain.Model;
using Infrastructure.Common;
using Infrastructure.Stores.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Stores.CommandHandlers
{
    public class CreateStoreCommandHandler : IRequestHandler<CreateStoreCommand, OperationResult<Guid>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IPersistence _persistence;

        public CreateStoreCommandHandler(AppDbContext context, IMapper mapper, IPersistence persistence)
        {
            _context = context;
            _mapper = mapper;
            _persistence = persistence;
        }
        public async Task<OperationResult<Guid>> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Guid>();

            var store = _mapper.Map<Store>(request);

            await _context.Stores.AddAsync(store, cancellationToken);

            var persistence = await _persistence.SaveChangesAsync();

            if(persistence == 0)
            {
                return result.AddError(ErrorMessages.CouldNotAddToDatabase);
            }

            return result;
        }
    }
}
