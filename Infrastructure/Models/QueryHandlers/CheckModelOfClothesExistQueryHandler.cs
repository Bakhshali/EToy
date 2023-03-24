using DataAccess.Database;
using Infrastructure.Models.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Models.QueryHandlers
{
    public class CheckModelOfClothesExistQueryHandler : IRequestHandler<CheckModelOfClothesExistQuery, bool>
    {
        private readonly AppDbContext _context;

        public CheckModelOfClothesExistQueryHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(CheckModelOfClothesExistQuery request, CancellationToken cancellationToken)
        {
            return await _context.ModelOfClothes.AsNoTracking().AnyAsync(m => m.Name == request.Name, cancellationToken);
        }
    }
}
