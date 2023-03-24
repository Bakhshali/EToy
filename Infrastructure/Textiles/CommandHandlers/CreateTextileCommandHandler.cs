using AutoMapper;
using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Domain.Model;
using Infrastructure.Common;
using Infrastructure.Textiles.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Textiles.CommandHandlers
{
    public class CreateTextileCommandHandler : IRequestHandler<CreateTextileCommand, OperationResult<Guid>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IPersistence _persistence;

        public CreateTextileCommandHandler(AppDbContext context,IMapper mapper,IPersistence persistence)
        {
            _context = context;
            _mapper = mapper;
            _persistence = persistence;
        }
        public async Task<OperationResult<Guid>> Handle(CreateTextileCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Guid>();
            var textile = _mapper.Map<Textile>(request);

           await _context.Textiles.AddAsync(textile);

            var persistence = await _persistence.SaveChangesAsync();

            if(persistence == 0)
            {
                return result.AddError(ErrorMessages.CouldNotAddToDatabase);
            }

            return result;
        }
    }
}
