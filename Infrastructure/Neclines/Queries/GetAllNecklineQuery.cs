using DataAccess.Pagination;
using Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Neclines.Queries
{
    public class GetAllNecklineQuery:IRequest<PaginatedList<Neckline>>
    {
        public int Page { get; set; }
        public int Size { get; set; }

        public GetAllNecklineQuery(int page,int size)
        {
            Page = page;
            Size = size;
        }
    }
}
