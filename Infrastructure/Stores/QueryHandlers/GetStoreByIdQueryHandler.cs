using AutoMapper;
using DataAccess.Database;
using Infrastructure.Stores.Queries;
using Infrastructure.Stores.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Stores.QueryHandlers
{
    public class GetStoreByIdQueryHandler : IRequestHandler<GetStoreByIdQuery, GetStoreVm>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetStoreByIdQueryHandler(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GetStoreVm> Handle(GetStoreByIdQuery request, CancellationToken cancellationToken)
        {
            var store = await _context.Stores.AsNoTracking().SingleOrDefaultAsync(s => s.Id == request.Id);

            if(store.Id == null)
            {
                return null;
            }

            return _mapper.Map<GetStoreVm>(store);
        }
    }
}
