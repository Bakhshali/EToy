using DataAccess.Database;
using Domain.Model;
using Infrastructure.Models.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Models.QueryHandlers
{
    public class GetModelOfClothesSelectListQueryHandler : IRequestHandler<GetModelOfClothesSelectListQuery, SelectList>
    {
        private readonly AppDbContext _context;

        public GetModelOfClothesSelectListQueryHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<SelectList> Handle(GetModelOfClothesSelectListQuery request, CancellationToken cancellationToken)
        {
            var model = await _context.ModelOfClothes.ToListAsync(cancellationToken);

            if(request.Id != Guid.Empty)
            {
                return new SelectList(model, nameof(ModelOfClothes.Id), nameof(ModelOfClothes.Name), request.Id);
            }

            return new SelectList(model, nameof(ModelOfClothes.Id), nameof(ModelOfClothes.Name));
        }
    }
}
