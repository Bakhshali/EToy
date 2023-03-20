using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.ClothesCategories.Queries
{
    public class GetAllCategorySelectListQuery :IRequest<SelectList>
    {
        public Guid Id { get; set; }

        public GetAllCategorySelectListQuery(Guid id)
        {
            Id = id;
        }
    }
}
