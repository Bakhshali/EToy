using DataAccess.Database;
using DataAccess.Pagination;
using Domain.Model;
using Infrastructure.Stores.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Stores.QueryHandlers
{
    public class GetAllStoreSelectListQueryHandler : IRequestHandler<GetAllStoreSelectListQuery, SelectList>
    {
        private readonly AppDbContext _conetext;

        public GetAllStoreSelectListQueryHandler(AppDbContext conetext)
        {
            _conetext = conetext;
        }
        public async Task<SelectList> Handle(GetAllStoreSelectListQuery request, CancellationToken cancellationToken)
        {
            var stores = await _conetext.Stores.ToListAsync(cancellationToken);

            if(request.Id != Guid.Empty)
            {
                return new SelectList(stores, nameof(Store.Id), nameof(Store.Name), request.Id);
            }

            return new SelectList(stores, nameof(Store.Id), nameof(Store.Name));
        }
    }
}
