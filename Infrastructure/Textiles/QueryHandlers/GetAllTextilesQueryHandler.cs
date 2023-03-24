using DataAccess.Database;
using DataAccess.Pagination;
using Domain.Model;
using Infrastructure.Textiles.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Textiles.QueryHandlers
{
    public class GetAllTextilesQueryHandler : IRequestHandler<GetAllTextilesQuery, PaginatedList<Textile>>
    {
        private readonly AppDbContext _context;

        public GetAllTextilesQueryHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<Textile>> Handle(GetAllTextilesQuery request, CancellationToken cancellationToken)
        {
            var textiles = _context.Textiles.Include(t => t.ClothesTextile).AsNoTracking().OrderByDescending(t => t.CreatedAt);

            return await PaginatedList<Textile>.CreateAsync(textiles, request.Page, request.Size);
        }
    }
}
