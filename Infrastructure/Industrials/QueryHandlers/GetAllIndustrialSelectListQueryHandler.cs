using DataAccess.Database;
using Domain.Model;
using Infrastructure.Industrials.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Industrials.QueryHandlers
{
    public class GetAllIndustrialSelectListQueryHandler : IRequestHandler<GetAllIndustrialSelectListQuery, SelectList>
    {
        private readonly AppDbContext _context;

        public GetAllIndustrialSelectListQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<SelectList> Handle(GetAllIndustrialSelectListQuery request, CancellationToken cancellationToken)
        {
            var industrial = await _context.Industrials.ToListAsync(cancellationToken);

            if (request.Id !=Guid.Empty)
            {
                return new SelectList(industrial, nameof(Industrial.Id), nameof(Industrial.Name), request.Id);
            }

            return new SelectList(industrial, nameof(Industrial.Id), nameof(Industrial.Name));
        }
    }
}
