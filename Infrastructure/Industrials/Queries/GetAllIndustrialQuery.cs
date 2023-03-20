using DataAccess.Pagination;
using Domain.Model;
using Infrastructure.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Industrials.Queries
{
    public class GetAllIndustrialQuery:IRequest<PaginatedList<Industrial>>
    {
        public int Page { get; set; }
        public int Size { get; set; }

        public GetAllIndustrialQuery(int page,int size)
        {
            Page = page;
            Size = size;
        }
    }
}
