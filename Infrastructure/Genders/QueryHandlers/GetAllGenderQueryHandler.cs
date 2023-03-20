using DataAccess.Database;
using DataAccess.Pagination;
using Domain.Model;
using Infrastructure.Genders.Queries;
using Infrastructure.Genders.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Genders.QueryHandlers
{
    public class GetAllGenderQueryHandler : IRequestHandler<GetAllGenderQuery, PaginatedList<Gender>>
    {
        private readonly AppDbContext _context;

        public GetAllGenderQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedList<Gender>> Handle(GetAllGenderQuery request, CancellationToken cancellationToken)
        {
            var gender = _context.Genders.Include(c => c.ClothesGender).AsNoTracking().OrderByDescending(c => c.CreatedAt);
            var result = await PaginatedList<Gender>.CreateAsync(gender, request.Page, request.Size);
            return result;
        }
    }
}
