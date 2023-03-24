using DataAccess.Database;
using Domain.Model;
using Infrastructure.Textiles.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Textiles.QueryHandlers
{
    public class GetTextileSelectListQueryHandler : IRequestHandler<GetTextileSelectListQuery, SelectList>
    {
        private readonly AppDbContext _context;

        public GetTextileSelectListQueryHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<SelectList> Handle(GetTextileSelectListQuery request, CancellationToken cancellationToken)
        {
            var textiles = await _context.Textiles.ToListAsync(cancellationToken);

            if(request.Id != Guid.Empty)
            {
                return new SelectList(textiles, nameof(Textile.Id), nameof(Textile.Name), request.Id);
            }

            return new SelectList(textiles, nameof(Textile.Id), nameof(Textile.Name));
        }
    }
}
