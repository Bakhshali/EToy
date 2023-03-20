using DataAccess.Pagination;
using Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.ClothesCategories.Queries
{
    public class GetAllCategoryQuery:IRequest<PaginatedList<CategoryOfClothes>>
    {
        public int Page { get; set; }
        public int Size { get; set; }

        public GetAllCategoryQuery(int page,int size)
        {
            Page = page;
            Size = size;
        }
    }
}
