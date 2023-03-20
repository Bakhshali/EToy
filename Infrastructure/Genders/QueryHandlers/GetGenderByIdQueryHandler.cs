using AutoMapper;
using DataAccess.Database;
using Domain.Model;
using Infrastructure.Genders.Queries;
using Infrastructure.Genders.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Genders.QueryHandlers
{
    public class GetGenderByIdQueryHandler : IRequestHandler<GetGenderByIdQuery, GetGenderVm>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetGenderByIdQueryHandler(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetGenderVm> Handle(GetGenderByIdQuery request, CancellationToken cancellationToken)
        {
            var gender = await _context.Genders.AsNoTracking().SingleOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (gender is null)
            {
                return null;
            }

            return _mapper.Map<GetGenderVm>(gender);
        }
    }
}
