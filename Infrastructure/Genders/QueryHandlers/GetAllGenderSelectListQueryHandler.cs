using DataAccess.Database;
using Domain.Model;
using Infrastructure.Genders.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Genders.QueryHandlers
{
    public class GetAllGenderSelectListQueryHandler : IRequestHandler<GetAllGenderSelectListQuery, SelectList>
    {
        private readonly AppDbContext _context;

        public GetAllGenderSelectListQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<SelectList> Handle(GetAllGenderSelectListQuery request, CancellationToken cancellationToken)
        {
            var gender = await _context.Genders.ToListAsync(cancellationToken);

            if (request.Id != Guid.Empty)
            {
                return new SelectList(gender, nameof(Gender.Id), nameof(Gender.Name), request.Id);
            }

            return new SelectList(gender, nameof(Gender.Id), nameof(Gender.Name));
        }
    }
}
