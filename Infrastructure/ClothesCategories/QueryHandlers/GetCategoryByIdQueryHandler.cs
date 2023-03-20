using AutoMapper;
using DataAccess.Database;
using Infrastructure.ClothesCategories.Queries;
using Infrastructure.ClothesCategories.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ClothesCategories.QueryHandlers
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, GetCategoryVm>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetCategoryByIdQueryHandler(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetCategoryVm> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.AsNoTracking()
               .SingleOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            if (category is null)
            {
                return null;
            }

            return _mapper.Map<GetCategoryVm>(category);
        }
    }
}
