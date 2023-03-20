using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Industrials.Queries
{
    public class GetAllIndustrialSelectListQuery:IRequest<SelectList>
    {
        public Guid Id { get; set; }

        public GetAllIndustrialSelectListQuery(Guid id)
        {
            Id = id;   
        }
    }
}
