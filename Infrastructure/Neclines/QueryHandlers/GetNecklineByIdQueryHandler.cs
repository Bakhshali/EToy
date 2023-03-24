using AutoMapper;
using DataAccess.Database;
using Infrastructure.Genders.ViewModels;
using Infrastructure.Neclines.Queries;
using Infrastructure.Neclines.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Neclines.QueryHandlers
{
    public class GetNecklineByIdQueryHandler : IRequestHandler<GetNecklineByIdQuery, GetNecklineVm>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetNecklineByIdQueryHandler(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetNecklineVm> Handle(GetNecklineByIdQuery request, CancellationToken cancellationToken)
        {
            var neckline = await _context.Necklines.AsNoTracking().SingleOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (neckline is null)
            {
                return null;
            }

            return _mapper.Map<GetNecklineVm>(neckline);
        }
    }
}
