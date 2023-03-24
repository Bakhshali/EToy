using DataAccess.Database;
using Infrastructure.Textiles.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Textiles.QueryHandlers
{
    public class CheckPositionExistQueryHandler : IRequestHandler<CheckPositionExistQuery, bool>
    {
        private readonly AppDbContext _context;

        public CheckPositionExistQueryHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(CheckPositionExistQuery request, CancellationToken cancellationToken)
        {
            return await _context.Textiles.AsNoTracking().AnyAsync(t => t.Name == request.Name, cancellationToken);
        }
    }
}
