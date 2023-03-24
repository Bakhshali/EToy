using DataAccess.Database;
using DataAccess.Pagination;
using Domain.Model;
using Infrastructure.Industrials.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Industrials.QueryHandlers
{
    public class GetAllIndustrialQueryHandler : IRequestHandler<GetAllIndustrialQuery, PaginatedList<Industrial>>
    {
        private readonly AppDbContext _context;

        public GetAllIndustrialQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public  async Task<PaginatedList<Industrial>> Handle(GetAllIndustrialQuery request, CancellationToken cancellationToken)
        {
            var industrial =  _context.Industrials.Include(c=>c.ClothesIndustrial).AsNoTracking().OrderByDescending(c=>c.CreatedAt);
            var result = await PaginatedList<Industrial>.CreateAsync(industrial, request.Page, request.Size);
            return result;
        }
    }
}
