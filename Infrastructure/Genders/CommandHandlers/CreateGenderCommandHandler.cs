using AutoMapper;
using DataAccess.Database;
using DataAccess.Persistence;
using Infrastructure.Common;
using Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.ClothesCategories.Commands;
using DataAccess.Constants;
using Infrastructure.Genders.Commands;

namespace Infrastructure.Genders.CommandHandler
{
    public class CreateGenderCommandHandler : IRequestHandler<CreateGenderCommand, OperationResult<int>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IPersistence _persistence;

        public CreateGenderCommandHandler(AppDbContext context, IMapper mapper, IPersistence persistence)
        {
            _context = context;
            _mapper = mapper;
            _persistence = persistence;
        }

        public async Task<OperationResult<int>> Handle(CreateGenderCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<int>();

            var gender = _mapper.Map<Gender>(request);
            await _context.Genders.AddAsync(gender, cancellationToken);

            var persistence = await _persistence.SaveChangesAsync();

            if (persistence == 0)
            {
                return result.AddError(ErrorMessages.CouldNotAddToDatabase);
            }

            return result;
        }
    }
}
