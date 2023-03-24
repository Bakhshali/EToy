using AutoMapper;
using DataAccess.Database;
using Infrastructure.Industrials.Queries;
using Infrastructure.Industrials.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Industrials.QueryHandlers
{
    public class GetIndustrialByIdQueryHandler : IRequestHandler<GetIndustrialByIdQuery, GetIndustrialVm>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetIndustrialByIdQueryHandler(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetIndustrialVm> Handle(GetIndustrialByIdQuery request, CancellationToken cancellationToken)
        {
            var industrial = await _context.Industrials.AsNoTracking().SingleOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (industrial is null)
            {
                return null;
            }

            return _mapper.Map<GetIndustrialVm>(industrial);
        }
    }
}
