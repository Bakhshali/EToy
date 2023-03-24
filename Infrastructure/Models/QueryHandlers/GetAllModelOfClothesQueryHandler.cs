using DataAccess.Database;
using DataAccess.Pagination;
using Domain.Model;
using Infrastructure.Models.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Models.QueryHandlers
{
    public class GetAllModelOfClothesQueryHandler : IRequestHandler<GetAllModelOfClothesQuery, PaginatedList<ModelOfClothes>>
    {
        private readonly AppDbContext _context;

        public GetAllModelOfClothesQueryHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<ModelOfClothes>> Handle(GetAllModelOfClothesQuery request, CancellationToken cancellationToken)
        {
            var models = _context.ModelOfClothes.Include(m => m.ClothesModel).AsNoTracking().OrderByDescending(m => m.CreatedAt);

            return await PaginatedList<ModelOfClothes>.CreateAsync(models, request.Page, request.Size);
        }
    }
}
