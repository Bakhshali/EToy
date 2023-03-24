using DataAccess.Pagination;
using Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Discounts.Queries
{
    public class GetAllDiscountsQuery : IRequest<PaginatedList<Discount>>
    {
        public GetAllDiscountsQuery(int page,int size)
        {
            Page = page;
            Size = size;
        }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
