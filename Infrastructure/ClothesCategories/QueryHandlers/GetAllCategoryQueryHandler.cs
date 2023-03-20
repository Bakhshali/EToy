using DataAccess.Database;
using DataAccess.Pagination;
using Domain.Model;
using Infrastructure.ClothesCategories.Queries;
using Infrastructure.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ClothesCategories.QueryHandlers
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, PaginatedList<CategoryOfClothes>>
    {
        private readonly AppDbContext _context;

        public GetAllCategoryQueryHandler(AppDbContext context)
        {
           _context = context;
        }

        public async Task<PaginatedList<CategoryOfClothes>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = _context.Categories.Include(c=>c.ClothesCategory).AsNoTracking().OrderByDescending(c=>c.CreatedAt);
            var result =  await PaginatedList<CategoryOfClothes>.CreateAsync(category, request.Page, request.Size);
            return result;
        }
    }
}
