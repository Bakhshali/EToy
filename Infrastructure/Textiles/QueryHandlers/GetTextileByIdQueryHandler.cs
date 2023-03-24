using AutoMapper;
using DataAccess.Database;
using Infrastructure.Textiles.Queries;
using Infrastructure.Textiles.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Textiles.QueryHandlers
{
    public class GetTextileByIdQueryHandler : IRequestHandler<GetTextileByIdQuery, GetTextileVm>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetTextileByIdQueryHandler(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GetTextileVm> Handle(GetTextileByIdQuery request, CancellationToken cancellationToken)
        {
            var textile = await _context.Textiles.AsNoTracking().SingleOrDefaultAsync(t => t.Id == request.Id);

            if(request.Id == null)
            {
                return null;
            }

            return _mapper.Map<GetTextileVm>(textile);
        }
    }
}
