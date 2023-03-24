using Domain.Model;
using DataAccess.Pagination;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Stores.Queries
{
    public class GetAllStoresQuery : IRequest<PaginatedList<Store>>
    {
        public GetAllStoresQuery(int page,int size)
        {
            Page = page;
            Size = size;
        }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
