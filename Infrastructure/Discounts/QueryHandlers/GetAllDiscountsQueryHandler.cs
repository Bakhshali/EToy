using DataAccess.Database;
using DataAccess.Pagination;
using Domain.Model;
using Infrastructure.Discounts.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Discounts.QueryHandlers
{
    public class GetAllDiscountsQueryHandler : IRequestHandler<GetAllDiscountsQuery, PaginatedList<Discount>>
    {
        private readonly AppDbContext _context;

        public GetAllDiscountsQueryHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<Discount>> Handle(GetAllDiscountsQuery request, CancellationToken cancellationToken)
        {
            var discounts = _context.Discounts.Include(s => s.ClothesDiscount).AsNoTracking().OrderByDescending(s => s.CreatedAt);

            return await PaginatedList<Discount>.CreateAsync(discounts, request.Page, request.Size);
        }
    }
}
