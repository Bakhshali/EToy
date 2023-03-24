using DataAccess.Database;
using Domain.Model;
using Infrastructure.Discounts.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Discounts.QueryHandlers
{
    public class GetAllDiscountsSelectListQueryHandler : IRequestHandler<GetAllDiscountSelectListQuery, SelectList>
    {
        private readonly AppDbContext _context;

        public GetAllDiscountsSelectListQueryHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<SelectList> Handle(GetAllDiscountSelectListQuery request, CancellationToken cancellationToken)
        {
            var discounts = await _context.Discounts.ToListAsync(cancellationToken);
            if(request.Id != Guid.Empty)
            {
                return new SelectList(discounts, nameof(Discount.Id), nameof(Discount.Percent),request.Id);
            }

            return new SelectList(discounts, nameof(Discount.Id), nameof(Discount.Percent));
        }
    }
}
