using AutoMapper;
using DataAccess.Database;
using DataAccess.Pagination;
using Domain.Model;
using Infrastructure.Neclines.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Neclines.QueryHandlers
{
    public class GetAllNecklineQueryHandler : IRequestHandler<GetAllNecklineQuery, PaginatedList<Neckline>>
    {
        private readonly AppDbContext _context;

        public GetAllNecklineQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedList<Neckline>> Handle(GetAllNecklineQuery request, CancellationToken cancellationToken)
        {
            var neckline = _context.Necklines.Include(c => c.DressNeckline).AsNoTracking().OrderByDescending(c => c.CreatedAt);
            var result = await PaginatedList<Neckline>.CreateAsync(neckline, request.Page, request.Size);
            return result;
        }
    }
}
