using DataAccess.Database;
using Domain.Model;
using Infrastructure.Neclines.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Neclines.QueryHandlers
{
    public class GetAllNecklineSelectListQueryHandler :IRequestHandler<GetAllNecklineSelectListQuery, SelectList>
    {
        private readonly AppDbContext _context;

        public GetAllNecklineSelectListQueryHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<SelectList> Handle(GetAllNecklineSelectListQuery request, CancellationToken cancellationToken)
        {
            var neckline = await _context.Necklines.ToListAsync(cancellationToken);

            if (request.Id != Guid.Empty)
            {
                return new SelectList(neckline, nameof(Neckline.Id), nameof(Neckline.Name), request.Id);
            }

            return new SelectList(neckline, nameof(Neckline.Id), nameof(Neckline.Name));
        }
    }
}
