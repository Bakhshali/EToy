using AutoMapper;
using DataAccess.Database;
using Infrastructure.Discounts.QueryHandlers;
using Infrastructure.Discounts.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Discounts.Queries
{
    public class GetDiscountByIdQueryHandler : IRequestHandler<GetDiscountByIdQuery, GetDiscountVm>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetDiscountByIdQueryHandler(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GetDiscountVm> Handle(GetDiscountByIdQuery request, CancellationToken cancellationToken)
        {
            var discount = await _context.Discounts.AsNoTracking().SingleOrDefaultAsync(d => d.Id == request.Id);
            if(discount is null)
            {
                return null;
            }

            return _mapper.Map<GetDiscountVm>(discount);
        }
    }
}
