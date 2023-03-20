using DataAccess.Pagination;
using Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Genders.Queries
{
    public class GetAllGenderQuery:IRequest<PaginatedList<Gender>>
    {
        public int Size { get; set; }
        public int Page { get; set; }

        public GetAllGenderQuery(int page,int size)
        {
            Size = size;
            Page = page;
        }
    }
}
