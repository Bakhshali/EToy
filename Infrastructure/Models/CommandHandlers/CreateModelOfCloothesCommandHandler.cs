using AutoMapper;
using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Domain.Model;
using Infrastructure.Common;
using Infrastructure.Models.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Models.CommandHandlers
{
    public class CreateModelOfCloothesCommandHandler : IRequestHandler<CreateModelOfCloothesCommand, OperationResult<Guid>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IPersistence _persistence;

        public CreateModelOfCloothesCommandHandler(AppDbContext context,IMapper mapper,IPersistence persistence)
        {
            _context = context;
            _mapper = mapper;
            _persistence = persistence;
        }

        public async Task<OperationResult<Guid>> Handle(CreateModelOfCloothesCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Guid>();

            var model = _mapper.Map<ModelOfClothes>(request);
            await _context.ModelOfClothes.AddAsync(model);

            var persistence = await _persistence.SaveChangesAsync();

            if(persistence == 0)
            {
                return result.AddError(ErrorMessages.CouldNotAddToDatabase);
            }

            return result;
        }
    }
}
