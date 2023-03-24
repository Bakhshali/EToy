using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Discounts.Queries
{
    public class GetAllDiscountSelectListQuery : IRequest<SelectList>
    {
        public GetAllDiscountSelectListQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
