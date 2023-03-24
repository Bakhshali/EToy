using DataAccess.Database;
using DataAccess.Pagination;
using Domain.Model;
using Infrastructure.Stores.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Stores.QueryHandlers
{
    public class GetAllStoresQueryHandler : IRequestHandler<GetAllStoresQuery, PaginatedList<Store>>
    {
        private readonly AppDbContext _context;

        public GetAllStoresQueryHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<Store>> Handle(GetAllStoresQuery request, CancellationToken cancellationToken)
        {
            var stores = _context.Stores.Include(s => s.ClothesStore).AsNoTracking().OrderByDescending(s => s.CreatedAt);

            return await PaginatedList<Store>.CreateAsync(stores, request.Page, request.Page);
        }
    }
}
