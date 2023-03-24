using DataAccess.Database;
using Infrastructure.Neclines.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Neclines.QueryHandlers
{
    public class CheckNecklineExistQueryHandler : IRequestHandler<CheckNecklineExistQuery, bool>
    {
        private readonly AppDbContext _context;

        public CheckNecklineExistQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CheckNecklineExistQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Necklines.AsNoTracking().AnyAsync(c => c.Name.ToUpper() == request.Name.ToUpper(), cancellationToken);
            return result;
        }
    }
}
