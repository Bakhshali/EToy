using DataAccess.Database;
using Infrastructure.Genders.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Genders.QueryHandlers
{
    public class CheckGenderExistQueryHandler : IRequestHandler<CheckGenderExistQuery, bool>
    {
        private readonly AppDbContext _context;

        public CheckGenderExistQueryHandler(AppDbContext context)
        {
           _context = context;
        }

        public async Task<bool> Handle(CheckGenderExistQuery request, CancellationToken cancellationToken)
        {
            var result =  await _context.Genders.AsNoTracking().AnyAsync(c => c.Name.ToUpper() == request.Name.ToUpper(), cancellationToken);
            return result;
        }
    }
}
