using DataAccess.Pagination;
using Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Textiles.Queries
{
    public class GetAllTextilesQuery : IRequest<PaginatedList<Textile>>
    {
        public GetAllTextilesQuery(int page,int size)
        {
            Page = page;
            Size = size;
        }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
