using DataAccess.Database;
using Infrastructure.ClothesCategories.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ClothesCategories.QueryHandlers
{
    public class CheckCategoryExistQueryHandler : IRequestHandler<CheckCategoryExistQuery, bool>
    {
        private readonly AppDbContext _context;

        public CheckCategoryExistQueryHandler(AppDbContext context)
        {
           _context = context;
        }
        public async Task<bool> Handle(CheckCategoryExistQuery request, CancellationToken cancellationToken)
        {
            return await _context.Categories.AsNoTracking().AnyAsync(c=>c.Name==request.Name,cancellationToken);
        }
    }
}
