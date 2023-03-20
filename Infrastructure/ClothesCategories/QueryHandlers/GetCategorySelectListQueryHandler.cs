using DataAccess.Database;
using Domain.Model;
using Infrastructure.ClothesCategories.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ClothesCategories.QueryHandlers
{
    public class GetCategorySelectListQueryHandler : IRequestHandler<GetAllCategorySelectListQuery, SelectList>
    {
        private readonly AppDbContext _context;

        public GetCategorySelectListQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<SelectList> Handle(GetAllCategorySelectListQuery request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.ToListAsync(cancellationToken);

            if (request.Id != Guid.Empty)
            {
                return new SelectList(category, nameof(CategoryOfClothes.Id), nameof(CategoryOfClothes.Name), request.Id);
            }

            return new SelectList(category, nameof(CategoryOfClothes.Id), nameof(CategoryOfClothes.Name));


        }
    }
}
