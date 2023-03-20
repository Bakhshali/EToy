using Infrastructure.ClothesCategories.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.ClothesCategories.Queries
{
    public class GetCategoryByIdQuery:IRequest<GetCategoryVm>
    {
        public GetCategoryByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
